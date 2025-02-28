using UnityEditor;
using UnityEngine;

namespace EnivStudios.EnivInspector
{
    [CustomPropertyDrawer(typeof(NameAttribute))]
    public class NameDrawer : EnivInspectorDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            NameAttribute labelAttribute = attribute as NameAttribute;

            EditorGUI.PropertyField(position, property, new GUIContent(labelAttribute.label), true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }
    }
}