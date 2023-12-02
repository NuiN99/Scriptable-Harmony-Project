using System;
using UnityEngine;
using System.IO;
using NuiN.ScriptableVariables.Core.RuntimeSet.Base;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Base;
using NuiN.ScriptableVariables.Core.Variable.Base;
using UnityEditor;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Core.Tools
{ 
    [CreateAssetMenu(menuName = "ScriptableVariables/Tools/CustomTypeScriptGenerator", fileName = "Custom Type Script Generator")]
    internal class CustomTypeScriptGenerator : ScriptableObject
    {
#if UNITY_EDITOR
        enum ObjectType { Variable, RuntimeSet, RuntimeSingle }
        
        const string SCRIPT_TEMPLATE =
@"using UnityEngine;
using NuiN.ScriptableVariables.Core.{SingularSuffix}.Base;

namespace NuiN.ScriptableVariables.CustomTypes.{Suffix}
{   
    [CreateAssetMenu(menuName = ""ScriptableVariables/Custom/{Suffix}/{Type}"", fileName = ""{FileName}"")]
    internal class {TypedType}SO : {BaseClass}<{Type}> { }
}";

        [SerializeField] ObjectType objectType = ObjectType.RuntimeSet;
    
        [SerializeField] string displayType = "GameObject";

        [TextArea(10, 10)] [SerializeField] string scriptPreview;

        [SerializeField] bool autoUpdateTemplate = true;
        [SerializeField] bool autoUpdatePath = true;
        [SerializeField] bool overwriteExisting;
        
        [SerializeField] string constantPath = "Assets/NuiN/ScriptableVariables/CustomTypes";
        [SerializeField] string updatedPath;

        void OnValidate()
        {
            if (autoUpdateTemplate) scriptPreview = AdjustedScriptPreview();
            if (autoUpdatePath) updatedPath = AdjustedPath();
        }

        void Reset()
        {
            scriptPreview = AdjustedScriptPreview();
            updatedPath = AdjustedPath();
        }

        public void GenerateScript()
        {
            scriptPreview = AdjustedScriptPreview();
            if(autoUpdatePath) updatedPath = AdjustedPath();
            GenerateCSharpFile($"{TypedType()}SO", scriptPreview);
        }

        string AdjustedScriptPreview()
        {
            string template = SCRIPT_TEMPLATE;

            template = template.Replace("{Type}", displayType);
            template = template.Replace("{TypedType}", TypedType());
            template = template.Replace("{BaseClass}", BaseClass());
            template = template.Replace("{Suffix}", Suffix());
            template = template.Replace("{SingularSuffix}", SingularSuffix());
            template = template.Replace("{FileName}", FileName());
        
            return template;
        }
        
        string TypedType()
        {
            return objectType switch
            {
                ObjectType.Variable => $"{displayType}Variable",
                ObjectType.RuntimeSet => $"{displayType}RuntimeSet",
                ObjectType.RuntimeSingle => $"{displayType}RuntimeSingle",
                _ => displayType
            };
        }

        string AdjustedPath()
        {
            return $"{constantPath}/{Suffix()}";
        }

        string SingularSuffix()
        {
            return objectType switch
            {
                ObjectType.Variable => "Variable",
                ObjectType.RuntimeSet => "RuntimeSet",
                ObjectType.RuntimeSingle => "RuntimeSingle",
                _ => ""
            };
        }

        string Suffix()
        {
            return objectType switch
            {
                ObjectType.Variable => "Variables",
                ObjectType.RuntimeSet => "RuntimeSets",
                ObjectType.RuntimeSingle => "RuntimeSingles",
                _ => ""
            };
        }

        string BaseClass()
        {
            return objectType switch
            {
                ObjectType.Variable => nameof(ScriptableVariableBaseSO<object>),
                ObjectType.RuntimeSet => nameof(RuntimeSetBaseSO<Object>),
                ObjectType.RuntimeSingle => nameof(RuntimeSingleBaseSO<Object>),
                _ => ""
            };
        }

        string FileName()
        {
            return $"New {displayType} {SingularSuffix()}";
        }

        void GenerateCSharpFile(string fileName, string fileContents)
        {
            string filePath = Path.Combine(updatedPath, $"{fileName}.cs");

            if (File.Exists(filePath) && !overwriteExisting)
            {
                Debug.Log("Script already exists and 'Overwrite Existing' is disabled");
                return;
            }

            using (StreamWriter writer = new StreamWriter(filePath)) writer.Write(fileContents);

            AssetDatabase.Refresh();

            Debug.Log("Script Generated: " + fileName);
        }
#endif
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(CustomTypeScriptGenerator))]
    internal class VariableCreatorSOEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CustomTypeScriptGenerator scriptGenerator = (CustomTypeScriptGenerator)target;
            
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
            {
                normal = { textColor = new Color(1, 0.3f, 0f, 1f) },
                fontSize = 15,
                fontStyle = FontStyle.Bold
            };

            GUI.backgroundColor = new Color(0.6f, 0.9f, 1f, 1f);
            
            if (GUILayout.Button("Generate New Variable Script", buttonStyle, GUILayout.Height(50)))
            {
                scriptGenerator.GenerateScript();
            }
        }
    }
#endif
}
