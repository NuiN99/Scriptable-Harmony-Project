using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.Core.Attributes
{
    public class TypeMismatchFixAttribute : PropertyAttribute { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(TypeMismatchFixAttribute))]
    internal class TypeMismatchFixDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
        
            EditorGUI.ObjectField(position, property.objectReferenceValue, typeof(Object), true);

            EditorGUI.EndProperty();
        }
    }
#endif
}


