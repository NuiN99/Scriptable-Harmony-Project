using System;

namespace NuiN.ScriptableVariables.Generator
{
    
    using UnityEngine;
    using System.IO;
    using UnityEditor;

    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/Generator/VariableScriptGenerator", fileName = "Variable Script Generator")]
    public class VariableScriptGeneratorSO : ScriptableObject
    {
        enum DataType { Normal, Array, List }
        
        const string SCRIPT_TEMPLATE =
@"namespace NuiN.ScriptableVariables
{
    using UnityEngine;
    using NuiN.ScriptableVariables.Base;<Directives>
    
    [CreateAssetMenu(menuName = ""ScriptableObjects/Variables/<ActualType>"", fileName = ""New <DisplayType> Variable"")]
    public class <DisplayType>SO : VariableSO<<ActualType>> { }
}";
        
        [SerializeField] DataType dataType;
    
        [SerializeField] string displayType = "Float";
        [SerializeField] string actualType = "float";

        [TextArea(8, 8)] [SerializeField] string scriptPreview;

        [SerializeField] bool autoUpdateTemplate = true;
        [SerializeField] bool autoUpdatePath = true;
        [SerializeField] bool overwriteExisting;
        
        [SerializeField] string constantPath = "Assets/Plugins/NuiN/ScriptableVariables/VariableTypes";
        [SerializeField] string updatedPath;

        void OnValidate()
        {
            updatedPath = constantPath;
            if (autoUpdateTemplate) scriptPreview = AdjustedScriptPreview();
            if (autoUpdatePath) updatedPath = AdjustedPath();
        }

        public void Generate()
        {
            scriptPreview = AdjustedScriptPreview();
            if(autoUpdatePath) updatedPath = AdjustedPath();
            string newDisplayType = AdjustedDisplayType();
            GenerateCSharpFile($"{newDisplayType}SO", scriptPreview);
        }

        string AdjustedScriptPreview()
        {
            string template = SCRIPT_TEMPLATE;
            
            template = template.Replace("<ActualType>", AdjustedActualType());
            template = template.Replace("<DisplayType>", AdjustedDisplayType());
            template = template.Replace("<Directives>", GetRequiredDirectives());
        
            return template;
        }

        string AdjustedDisplayType()
        {
            return dataType switch
            {
                DataType.Normal => displayType,
                DataType.Array => $"{displayType}Array",
                DataType.List => $"{displayType}List",
                _ => displayType
            };
        }
        string AdjustedActualType()
        {
            return dataType switch
            {
                DataType.Normal => actualType,
                DataType.Array => $"{actualType}[]",
                DataType.List => $"List<{actualType}>",
                _ => actualType
            };
        }
        string AdjustedPath()
        {
            return dataType switch
            {
                DataType.Normal => $"{constantPath}/Normal",
                DataType.Array => $"{constantPath}/Array",
                DataType.List => $"{constantPath}/List",
                _ => constantPath
            };
        }
        string GetRequiredDirectives()
        {
            return dataType switch
            {
                DataType.List => 
    @"
    using System.Collections.Generic;",
                _ => null
            };
        }

        void GenerateCSharpFile(string fileName, string fileContents)
        {
            string filePath = Path.Combine(updatedPath, $"{fileName}.cs");

            if (File.Exists(filePath) && !overwriteExisting)
            {
                Debug.Log("Script already exists and Overwrite is disabled");
                return;
            }

            using (StreamWriter writer = new StreamWriter(filePath)) writer.Write(fileContents);

            AssetDatabase.Refresh();

            Debug.Log("Script Generated: " + fileName);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(VariableScriptGeneratorSO))]
    internal class VariableCreatorSOEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            VariableScriptGeneratorSO scriptGenerator = (VariableScriptGeneratorSO)target;
            
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = new Color(1, 0.3f, 0f, 1f);
            buttonStyle.fontSize = 15;
            buttonStyle.fontStyle = FontStyle.Bold;
            
            GUI.backgroundColor = new Color(0.6f, 0.9f, 1f, 1f);
            
            if (GUILayout.Button("Generate New Variable Script", buttonStyle, GUILayout.Height(50)))
            {
                scriptGenerator.Generate();
            }
        }
    }
#endif
}
