using UnityEditor;
using UnityEngine;

namespace NuiN.ScriptableVariables.Internal.Attributes
{
    public class TypeMismatchFixAttribute : PropertyAttribute { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(TypeMismatchFixAttribute))]
    internal class TypeMismatchFixDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
        
            EditorGUI.ObjectField(position, property.objectReferenceValue, typeof(Component), true);

            EditorGUI.EndProperty();
        }
    }
#endif
}


