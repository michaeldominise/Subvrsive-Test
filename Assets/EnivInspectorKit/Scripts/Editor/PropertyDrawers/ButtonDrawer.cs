using UnityEditor;
using UnityEngine;

namespace EnivStudios.EnivInspector
{
    [CustomPropertyDrawer(typeof(ButtonAttribute))]
    public class ButtonDrawer : EnivInspectorDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // Adjust the height of the drawer based on spaceAbove and spaceBelow
            return EditorGUIUtility.singleLineHeight + ((ButtonAttribute)attribute).spaceAbove + ((ButtonAttribute)attribute).spaceBelow;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Check if the property has the ButtonAttribute
            if (property.propertyType == SerializedPropertyType.String)
            {
                DrawButton(position, property, label);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use ButtonAttribute with string field");
            }
        }
    }
}