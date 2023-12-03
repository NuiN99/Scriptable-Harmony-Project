using System;
using UnityEngine;
using System.IO;
using NuiN.ScriptableVariables.Core.RuntimeSet.Base;
using NuiN.ScriptableVariables.Core.RuntimeSet.Components.Base;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Base;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Components.Base;
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
        
        const string COMPONENT_SCRIPT_TEMPLATE = 
@"using UnityEngine;
using NuiN.ScriptableVariables.Core.{SingularSuffix}.Components.Base;

namespace NuiN.ScriptableVariables.CustomTypes.{Suffix}.Components
{   
    public class {TypedType}Item : {BaseClass}<{Type}> { }
}";

        [SerializeField] ObjectType objectType = ObjectType.RuntimeSet;
    
        [SerializeField] string displayType = "GameObject";

        [TextArea(10, 10)] [SerializeField] string scriptPreview;

        bool _isComponent;

        [SerializeField] bool autoUpdateTemplate = true;
        [SerializeField] bool autoUpdatePath = true;
        [SerializeField] bool overwriteExisting;
        
        [SerializeField] string constantPath = "Assets/NuiN/ScriptableVariables/CustomTypes";
        [SerializeField] string updatedPath;

        void OnValidate()
        {
            if (autoUpdateTemplate) scriptPreview = AdjustedScriptPreview(SCRIPT_TEMPLATE);
            if (autoUpdatePath) updatedPath = AdjustedPath();
        }

        void Reset()
        {
            scriptPreview = AdjustedScriptPreview(SCRIPT_TEMPLATE);
            updatedPath = AdjustedPath();
        }

        public void GenerateScript()
        {
            scriptPreview = AdjustedScriptPreview(SCRIPT_TEMPLATE);
            if(autoUpdatePath) updatedPath = AdjustedPath();
            GenerateCSharpFile($"{TypedType()}SO", scriptPreview);

            if (objectType is not (ObjectType.RuntimeSet or ObjectType.RuntimeSingle)) return;

            _isComponent = true;
            scriptPreview = AdjustedScriptPreview(COMPONENT_SCRIPT_TEMPLATE);
            GenerateCSharpFile($"{TypedType()}Item", scriptPreview);
            _isComponent = false;
        }

        string AdjustedScriptPreview(string constTemplate)
        {
            constTemplate = constTemplate.Replace("{Type}", displayType);
            constTemplate = constTemplate.Replace("{TypedType}", TypedType());
            constTemplate = constTemplate.Replace("{BaseClass}", BaseClass());
            constTemplate = constTemplate.Replace("{Suffix}", Suffix());
            constTemplate = constTemplate.Replace("{SingularSuffix}", SingularSuffix());
            constTemplate = constTemplate.Replace("{FileName}", FileName());
        
            return constTemplate;
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

        string AdjustedPath() => $"{constantPath}/{Suffix()}";
        string Suffix() => SingularSuffix() + "s";
        string FileName() => $"New {displayType} {SingularSuffix()}";
        
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
        
        string BaseClass()
        {
            if (_isComponent)
            {
                return objectType switch
                {
                    ObjectType.RuntimeSet => nameof(RuntimeSetItemComponentBase<Object>),
                    ObjectType.RuntimeSingle => nameof(RuntimeSingleItemComponentBase<Object>),
                    ObjectType.Variable => null,
                    _ => null
                };
            }
            return objectType switch
            {
                ObjectType.Variable => nameof(ScriptableVariableBaseSO<object>),
                ObjectType.RuntimeSet => nameof(RuntimeSetBaseSO<Object>),
                ObjectType.RuntimeSingle => nameof(RuntimeSingleBaseSO<Object>),
                _ => ""
            };
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
