using UnityEngine;
using UnityEditor;
using System.IO;
using NuiN.ScriptableVariables.Core.RuntimeSet.Base;
using NuiN.ScriptableVariables.Core.RuntimeSet.Components.Base;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Base;
using NuiN.ScriptableVariables.Core.RuntimeSingle.Components.Base;
using NuiN.ScriptableVariables.Core.Variable.Base;
using NuiN.ScriptableVariables.Internal.Helpers;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Core.Tools
{
    public class CustomTypeScriptGeneratorWindow : EditorWindow
    {
        SOType _objectType = SOType.RuntimeSet;
        string _displayType = "GameObject";
        string _constantPath = "Assets/NuiN/ScriptableVariables/CustomTypes";
        string _updatedPath;
        string _scriptPreview;
        bool _autoUpdateTemplate = true;
        bool _autoUpdatePath = true;
        bool _overwriteExisting;

        bool _isComponent;
        
        const string SCRIPT_TEMPLATE =
@"using UnityEngine;
using NuiN.ScriptableVariables.Core.{SingularSuffix}.Base;

namespace NuiN.ScriptableVariables.CustomTypes.{Suffix}
{   
    [CreateAssetMenu(menuName = ""ScriptableVariables/Custom/{Suffix}/{Type}"", fileName = ""{FileName}"")]
    internal class {TypeWithSuffix}SO : {BaseClass}<{Type}> { }
}";
        
        const string COMPONENT_SCRIPT_TEMPLATE = 
@"using UnityEngine;
using NuiN.ScriptableVariables.Core.{SingularSuffix}.Components.Base;

namespace NuiN.ScriptableVariables.CustomTypes.{Suffix}.Components
{   
    public class {TypeWithSuffix}Item : {BaseClass}<{Type}> { }
}";

        [MenuItem("ScriptableVariables/Custom Type Script Generator")]
        static void ShowWindow()
        {
            CustomTypeScriptGeneratorWindow window = GetWindow<CustomTypeScriptGeneratorWindow>();
            window.titleContent = new GUIContent("Script Generator");
            window.Show();
        }

        Vector2 _scrollPosition;
        void OnGUI()
        {
            _objectType = (SOType)EditorGUILayout.EnumPopup("Object Type", _objectType);
            _displayType = EditorGUILayout.TextField("Display Type", _displayType);
            _constantPath = EditorGUILayout.TextField("Constant Path", _constantPath);
            _autoUpdateTemplate = EditorGUILayout.Toggle("Auto Update Template", _autoUpdateTemplate);
            _autoUpdatePath = EditorGUILayout.Toggle("Auto Update Path", _autoUpdatePath);
            _overwriteExisting = EditorGUILayout.Toggle("Overwrite Existing", _overwriteExisting);

            GUILayout.Space(10);

            if (GUILayout.Button("Generate New Variable Script", GUILayout.Height(30)))
            {
                GenerateScript();
            }

            GUILayout.Space(10);

            EditorGUILayout.LabelField("Script Preview:");

            using (var scrollView = new EditorGUILayout.ScrollViewScope(_scrollPosition, GUILayout.Height(200)))
            {
                _scrollPosition = scrollView.scrollPosition;
                _scriptPreview = EditorGUILayout.TextArea(_scriptPreview, GUILayout.ExpandHeight(true));
            }

            if (_autoUpdateTemplate) _scriptPreview = ScriptPreview(SCRIPT_TEMPLATE);
            if (_autoUpdatePath) _updatedPath = Path();
        }


        public void GenerateScript()
        {
            _scriptPreview = ScriptPreview(SCRIPT_TEMPLATE);
            if(_autoUpdatePath) _updatedPath = Path();
            GenerateCSharpFile($"{TypeWithSuffix()}SO", _scriptPreview);

            if (_objectType is not (SOType.RuntimeSet or SOType.RuntimeSingle)) return;

            _isComponent = true;
            _scriptPreview = ScriptPreview(COMPONENT_SCRIPT_TEMPLATE);
            GenerateCSharpFile($"{TypeWithSuffix()}Item", _scriptPreview);
            _isComponent = false;
        }

        string ScriptPreview(string constTemplate)
        {
            constTemplate = constTemplate.Replace("{Type}", _displayType);
            constTemplate = constTemplate.Replace("{TypeWithSuffix}", TypeWithSuffix());
            constTemplate = constTemplate.Replace("{BaseClass}", BaseClass());
            constTemplate = constTemplate.Replace("{Suffix}", Suffix());
            constTemplate = constTemplate.Replace("{SingularSuffix}", SingularSuffix());
            constTemplate = constTemplate.Replace("{FileName}", FileName());
        
            return constTemplate;
        }

        string TypeWithSuffix()
        {
            return _objectType switch
            {
                SOType.ScriptableVariable => $"{_displayType}{SingularSuffix()}",
                _ => $"{_displayType}{SingularSuffix()}"
            };
        }

        string Path() => $"{_constantPath}/{Suffix()}";

        string Suffix() => SingularSuffix() + "s";

        string FileName() => $"New {_displayType} {SingularSuffix()}";

        string SingularSuffix()
        {
            return _objectType switch
            {
                SOType.ScriptableVariable => "Variable",
                SOType.RuntimeSet => "RuntimeSet",
                SOType.RuntimeSingle => "RuntimeSingle",
                _ => ""
            };
        }

        string BaseClass()
        {
            if (_isComponent)
            {
                return _objectType switch
                {
                    SOType.RuntimeSet => nameof(RuntimeSetItemComponentBase<Object>),
                    SOType.RuntimeSingle => nameof(RuntimeSingleItemComponentBase<Object>),
                    SOType.ScriptableVariable => null,
                    _ => null
                };
            }
            return _objectType switch
            {
                SOType.ScriptableVariable => nameof(ScriptableVariableBaseSO<object>),
                SOType.RuntimeSet => nameof(RuntimeSetBaseSO<Object>),
                SOType.RuntimeSingle => nameof(RuntimeSingleBaseSO<Object>),
                _ => ""
            };
        }

        void GenerateCSharpFile(string fileName, string fileContents)
        {
            string filePath = System.IO.Path.Combine(_updatedPath, $"{fileName}.cs");

            if (File.Exists(filePath) && !_overwriteExisting)
            {
                Debug.Log("Script already exists and 'Overwrite Existing' is disabled");
                return;
            }

            using (StreamWriter writer = new StreamWriter(filePath)) writer.Write(fileContents);

            AssetDatabase.Refresh();

            Debug.Log("Script Generated: " + fileName);
        }
    }
}
