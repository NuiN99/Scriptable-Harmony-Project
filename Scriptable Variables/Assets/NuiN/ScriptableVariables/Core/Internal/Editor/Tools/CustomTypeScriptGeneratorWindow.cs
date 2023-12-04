using UnityEngine;
using UnityEditor;
using System.IO;
using NuiN.ScriptableVariables.Internal.Helpers;
using NuiN.ScriptableVariables.RuntimeSet.Base;
using NuiN.ScriptableVariables.RuntimeSet.Components.Base;
using NuiN.ScriptableVariables.RuntimeSingle.Base;
using NuiN.ScriptableVariables.RuntimeSingle.Components.Base;
using NuiN.ScriptableVariables.Variable.Base;
using Object = UnityEngine.Object;

namespace NuiN.ScriptableVariables.Core.Editor.Tools
{
    internal class CustomTypeScriptGeneratorWindow : EditorWindow
    {
        static SOType _dataType;
        static string _type;
        const string EMPTY_PATH_MESSAGE = "Please select a folder in the Project panel";
        string _path;
        static string _scriptPreview;
        static bool _lockPreview = true;
        static bool _overwriteExisting;

        static bool _isComponent;

        // remove this functionality when created all commons
        const bool IS_COMMON = true;

        const string SCRIPT_TEMPLATE =
@"using UnityEngine;
using NuiN.ScriptableVariables.{SingularSuffix}.Base;

namespace NuiN.ScriptableVariables.{SingularSuffix}.{CustomOrCommon}
{   
    [CreateAssetMenu(
        menuName = ""ScriptableVariables/Custom/{Suffix}/{Type}"", 
        fileName = ""{FileName}"")]
    internal class {TypeWithSuffix}SO : {BaseClass}<{Type}> { }
}";
        
        const string COMPONENT_SCRIPT_TEMPLATE = 
@"using UnityEngine;
using NuiN.ScriptableVariables.{SingularSuffix}.Components.Base;

namespace NuiN.ScriptableVariables.{SingularSuffix}.Components.{CustomOrCommon}
{   
    public class {TypeWithSuffix}Item : {BaseClass}<{Type}> { }
}";
        
        static CustomTypeScriptGeneratorWindow _windowInstance;
        
        [MenuItem("ScriptableVariables/Custom Type Generator")]
        static void OpenWindow()
        {
            _windowInstance = GetWindow<CustomTypeScriptGeneratorWindow>();
            _windowInstance.titleContent = new GUIContent("Script Generator");
            _windowInstance.Show();
        }
        
        void OnEnable() => Selection.selectionChanged += UpdatePath;
        void OnDisable() => Selection.selectionChanged -= UpdatePath;
        
        void UpdatePath()
        {
            string selectedPath = GetSelectedFolderPath();
            if (string.IsNullOrEmpty(selectedPath)) return;
            
            _path = selectedPath;
            Repaint();
        }

        static string GetSelectedFolderPath()
        {
            Object[] selectedObjects = Selection.GetFiltered(typeof(Object), SelectionMode.Assets);
            if (selectedObjects.Length <= 0) return null;
            
            string path = AssetDatabase.GetAssetPath(selectedObjects[0]);
            if (File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
            }
            return path;
        }
        
        Vector2 _scrollPosition;
        void OnGUI()
        {
            GUILayout.Space(10);
            _dataType = (SOType)EditorGUILayout.EnumPopup("Data Type", _dataType);
            _type = EditorGUILayout.TextField("Type Name", _type);
            
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.TextField("Path", string.IsNullOrEmpty(_path) ? EMPTY_PATH_MESSAGE : _path);
            EditorGUI.EndDisabledGroup();
            
            _overwriteExisting = EditorGUILayout.Toggle("Overwrite Existing", _overwriteExisting);

            GUILayout.Space(10);

            EditorGUILayout.LabelField("Preview:");

            using (var scrollView = new EditorGUILayout.ScrollViewScope(_scrollPosition, GUILayout.Height(position.height - 200)))
            {
                _scrollPosition = scrollView.scrollPosition;
                if (_lockPreview) EditorGUI.BeginDisabledGroup(true);
                _scriptPreview = EditorGUILayout.TextArea(_scriptPreview, GUILayout.ExpandHeight(true));
                if (_lockPreview) EditorGUI.EndDisabledGroup();
            }
            _lockPreview = EditorGUILayout.Toggle("Lock Preview", _lockPreview);

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
            {
                normal = { textColor = new Color(1, 0.3f, 0f, 1f) },
                fontSize = 17,
                fontStyle = FontStyle.Bold,
                fixedHeight = 55 
            };
            Color ogColor = GUI.backgroundColor;
            GUI.backgroundColor = new Color(0.6f, 0.9f, 1f, 1f);

            if (GUILayout.Button("Generate Script", buttonStyle, GUILayout.ExpandWidth(true)))
            {
                bool emptyPath = string.IsNullOrEmpty(_path);
                bool emptyType = string.IsNullOrEmpty(_type);
                if (!emptyPath && !emptyType)
                {
                    GenerateScript();
                }
                else
                {
                    string warningMessage = "Empty {string} when attempting to create a new Custom Type Script";
                    warningMessage = emptyPath switch
                    {
                        true when emptyType => warningMessage.Replace("{string}", "Path and Type Name"),
                        true => warningMessage.Replace("{string}", "Path"),
                        _ => warningMessage.Replace("{string}", "Type Name")
                    };

                    Debug.LogWarning(warningMessage);
                }
            }

            GUI.backgroundColor = ogColor;

            if (_lockPreview) _scriptPreview = ScriptPreview(SCRIPT_TEMPLATE);
        }

        public void GenerateScript()
        {
            _scriptPreview = ScriptPreview(SCRIPT_TEMPLATE);
            GenerateScriptFile($"{GetTypeWithSuffix()}SO", _scriptPreview);

            if (_dataType is not (SOType.RuntimeSet or SOType.RuntimeSingle)) return;

            _isComponent = true;
            _scriptPreview = ScriptPreview(COMPONENT_SCRIPT_TEMPLATE);
            GenerateScriptFile($"{GetTypeWithSuffix()}Item", _scriptPreview);
            _isComponent = false;
        }

        static string ScriptPreview(string template)
        {
            template = template.Replace("{Type}", _type);
            template = template.Replace("{TypeWithSuffix}", GetTypeWithSuffix());
            template = template.Replace("{BaseClass}", GetBaseClass());
            template = template.Replace("{Suffix}", GetPluralSuffix());
            template = template.Replace("{SingularSuffix}", GetSingularSuffix());
            template = template.Replace("{FileName}", GetFileName());
            template = template.Replace("{CustomOrCommon}", IS_COMMON ? "Common" : "Custom");
        
            return template;
        }

        static string GetTypeWithSuffix()
        {
            return _dataType switch
            {
                SOType.ScriptableVariable => $"{_type}{GetSingularSuffix()}",
                _ => $"{_type}{GetSingularSuffix()}"
            };
        }

        static string GetPluralSuffix() => GetSingularSuffix() + "s";

        static string GetFileName() => $"New {_type} {GetSingularSuffix()}";

        static string GetSingularSuffix()
        {
            return _dataType switch
            {
                SOType.ScriptableVariable => "Variable",
                SOType.RuntimeSet => "RuntimeSet",
                SOType.RuntimeSingle => "RuntimeSingle",
                _ => ""
            };
        }

        static string GetBaseClass()
        {
            if (_isComponent)
            {
                return _dataType switch
                {
                    SOType.RuntimeSet => nameof(RuntimeSetItemComponentBase<Object>),
                    SOType.RuntimeSingle => nameof(RuntimeSingleItemComponentBase<Object>),
                    SOType.ScriptableVariable => null,
                    _ => null
                };
            }
            return _dataType switch
            {
                SOType.ScriptableVariable => nameof(ScriptableVariableBaseSO<object>),
                SOType.RuntimeSet => nameof(RuntimeSetBaseSO<Object>),
                SOType.RuntimeSingle => nameof(RuntimeSingleBaseSO<Object>),
                _ => ""
            };
        }

        void GenerateScriptFile(string fileName, string fileContents)
        {
            string folderName = _type;
            string folderPath = Path.Combine(_path, folderName);

            if (_dataType is SOType.RuntimeSet or SOType.RuntimeSingle)
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            else
            {
                folderPath = _path;
            }

            string filePath = Path.Combine(folderPath, $"{fileName}.cs");

            if (File.Exists(filePath) && !_overwriteExisting)
            {
                Debug.Log("Script already exists and 'Overwrite Existing' is disabled");
                return;
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(fileContents);
            }

            AssetDatabase.Refresh();

            Debug.Log("Script Generated: " + fileName);
        }
    }
}
