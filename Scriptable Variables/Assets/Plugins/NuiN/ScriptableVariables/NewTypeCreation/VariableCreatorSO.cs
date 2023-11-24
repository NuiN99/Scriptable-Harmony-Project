using UnityEngine;
using System.IO;
using UnityEditor;

[CreateAssetMenu(menuName = "ScriptableObjects/VariableSOClassGenerator")]
public class VariableCreatorSO : ScriptableObject
{
    [SerializeField] string path = "Assets/Plugins/NuiN/ScriptableVariables/VariableSOClasses/Generated";
    
    [SerializeField] string variableTypeUpper;
    [SerializeField] string variableType;
    
    const string SCRIPT_TEMPLATE =
@"namespace NuiN.ScriptableVariables
{
    using UnityEngine;

    [CreateAssetMenu(menuName = ""ScriptableObjects/Variables/<TypeUpper> Variable"", fileName = ""<TypeUpper>Variable"")]
    public class <TypeUpper>SO : VariableSO<<Type>> { }
}";
    
    public void Generate()
    {
        string scriptContents = GetModifiedTemplate();
        GenerateCSharpFile($"{variableTypeUpper}SO", scriptContents);
    }

    string GetModifiedTemplate()
    {
        string template = SCRIPT_TEMPLATE;
        template = template.Replace("<Type>", variableType);
        template = template.Replace("<TypeUpper>", variableTypeUpper);
        
        return template;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void GenerateCSharpFile(string fileName, string fileContents)
    {
        string filePath = Path.Combine(path, fileName + ".cs");

        if (File.Exists(filePath))
        {
            return;
        }

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write(fileContents);
        }

        UnityEditor.AssetDatabase.Refresh();

        Debug.Log("New ScriptableObject Variable Script Generated : " + fileName);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(VariableCreatorSO))]
public class VariableCreatorSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        VariableCreatorSO creator = (VariableCreatorSO)target;

        if (GUILayout.Button("Generate Variable Script"))
        {
            creator.Generate();
        }
    }
}
#endif