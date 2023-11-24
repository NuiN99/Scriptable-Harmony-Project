using UnityEngine;
using System.IO;
using UnityEditor;

[CreateAssetMenu(menuName = "ScriptableObjects/Variables/Generator/VariableScriptGenerator", fileName = "Variable Script Generator")]
public class VariableScriptGeneratorSO : ScriptableObject
{
    [SerializeField] string path = "Assets/Plugins/NuiN/ScriptableVariables/VariableClasses";
    
    [SerializeField] string displayType = "Float";
    [SerializeField] string actualType = "float";
    
    const string SCRIPT_TEMPLATE =
@"namespace NuiN.ScriptableVariables
{
    using UnityEngine;

    [CreateAssetMenu(menuName = ""ScriptableObjects/Variables/<ActualType>"", fileName = ""New <DisplayType> Variable"")]
    public class <DisplayType>SO : VariableSO<<ActualType>> { }
}";
    
    public void Generate()
    {
        string scriptContents = GetModifiedTemplate();
        GenerateCSharpFile($"{displayType}SO", scriptContents);
    }

    string GetModifiedTemplate()
    {
        string template = SCRIPT_TEMPLATE;
        template = template.Replace("<ActualType>", actualType);
        template = template.Replace("<DisplayType>", displayType);
        
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
[CustomEditor(typeof(VariableScriptGeneratorSO))]
public class VariableCreatorSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        VariableScriptGeneratorSO scriptGenerator = (VariableScriptGeneratorSO)target;

        if (GUILayout.Button("Generate Variable Script"))
        {
            scriptGenerator.Generate();
        }
    }
}
#endif