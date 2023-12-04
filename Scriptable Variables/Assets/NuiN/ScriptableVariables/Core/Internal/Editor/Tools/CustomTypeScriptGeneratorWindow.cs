﻿using UnityEngine;
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
        string _path;
        static string _scriptPreview;
        static bool _lockPreview = true;
        static bool _overwriteExisting;

        bool _isComponent;

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
        
        [MenuItem("Assets/Create/ScriptableVariables/Custom Type Script", false, 0)]
        static void OpenWindow()
        {
            string selectedPath = GetSelectedFolderPath();
            if (!string.IsNullOrEmpty(selectedPath))
            {
                _windowInstance = GetWindow<CustomTypeScriptGeneratorWindow>();
                _windowInstance.titleContent = new GUIContent("Script Generator");
                _windowInstance.Show();

                _windowInstance._path = selectedPath;
            }
            else
            {
                Debug.LogWarning("Please select a valid folder in the project view.");
            }

            return;
            
            string GetSelectedFolderPath()
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
        }

        Vector2 _scrollPosition;
        void OnGUI()
        {
            GUILayout.Space(10);
            _dataType = (SOType)EditorGUILayout.EnumPopup("Data Type", _dataType);
            _type = EditorGUILayout.TextField("Type", _type);
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
                fixedHeight = 75 
            };
            Color ogColor = GUI.backgroundColor;
            GUI.backgroundColor = new Color(0.6f, 0.9f, 1f, 1f);

            if (GUILayout.Button("Generate Script", buttonStyle, GUILayout.ExpandWidth(true)))
            {
                GenerateScript();
            }

            GUI.backgroundColor = ogColor;

            if (_lockPreview) _scriptPreview = ScriptPreview(SCRIPT_TEMPLATE);
        }

        public void GenerateScript()
        {
            _scriptPreview = ScriptPreview(SCRIPT_TEMPLATE);
            GenerateCSharpFile($"{TypeWithSuffix()}SO", _scriptPreview);

            if (_dataType is not (SOType.RuntimeSet or SOType.RuntimeSingle)) return;

            _isComponent = true;
            _scriptPreview = ScriptPreview(COMPONENT_SCRIPT_TEMPLATE);
            GenerateCSharpFile($"{TypeWithSuffix()}Item", _scriptPreview);
            _isComponent = false;
        }

        string ScriptPreview(string template)
        {
            template = template.Replace("{Type}", _type);
            template = template.Replace("{TypeWithSuffix}", TypeWithSuffix());
            template = template.Replace("{BaseClass}", BaseClass());
            template = template.Replace("{Suffix}", Suffix());
            template = template.Replace("{SingularSuffix}", SingularSuffix());
            template = template.Replace("{FileName}", FileName());
            template = template.Replace("{CustomOrCommon}", IS_COMMON ? "Common" : "Custom");
        
            return template;
        }

        string TypeWithSuffix()
        {
            return _dataType switch
            {
                SOType.ScriptableVariable => $"{_type}{SingularSuffix()}",
                _ => $"{_type}{SingularSuffix()}"
            };
        }

        string Suffix() => SingularSuffix() + "s";

        string FileName() => $"New {_type} {SingularSuffix()}";

        string SingularSuffix()
        {
            return _dataType switch
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

        void GenerateCSharpFile(string fileName, string fileContents)
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
