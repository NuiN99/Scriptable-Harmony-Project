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
        
            if (property.objectReferenceValue != null)
            {
                EditorGUI.ObjectField(position, property.objectReferenceValue, typeof(Component), true);
            }
            else
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
            

            EditorGUI.EndProperty();
        }
    }
#endif
}


