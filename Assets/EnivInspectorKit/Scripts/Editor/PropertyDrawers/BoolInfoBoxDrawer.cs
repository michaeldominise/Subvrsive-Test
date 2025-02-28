using UnityEditor;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

namespace EnivStudios.EnivInspector
{
    [CustomPropertyDrawer(typeof(BoolInfoBoxAttribute))]
    public class BoolInfoBoxDrawer : PropertyDrawer
    {
        private BoolInfoBoxAttribute helpBoxAttribute => (BoolInfoBoxAttribute)attribute;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // If bool is unchecked, reduce the total height to 0
            if (!IsBoolChecked(property))
            {
                return 0f;
            }

            float baseHeight = EditorGUI.GetPropertyHeight(property, label);
            float helpBoxHeight = GetHelpBoxHeight();

            // Calculate the total height for the property
            float totalHeight = baseHeight + helpBoxAttribute.spaceAbove + helpBoxAttribute.spaceBelow + helpBoxHeight;

            // Ensure at least one line height
            return Mathf.Max(totalHeight, EditorGUIUtility.singleLineHeight);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!IsBoolChecked(property))
            {
                // If bool is unchecked, don't draw anything
                return;
            }

            float helpBoxHeight = GetHelpBoxHeight();

            // Adjust the position for the help box
            Rect helpBoxRect = new Rect(position.x, position.y + helpBoxAttribute.spaceAbove, position.width, helpBoxHeight);
            EditorGUI.HelpBox(helpBoxRect, helpBoxAttribute.text, (UnityEditor.MessageType)helpBoxAttribute.messageType);

            // Adjust the position for the property field
            Rect propertyRect = new Rect(position.x, position.y + helpBoxHeight + helpBoxAttribute.spaceAbove + helpBoxAttribute.spaceBelow, position.width, EditorGUI.GetPropertyHeight(property, label));

            // Draw the property field
            EditorGUI.PropertyField(propertyRect, property, label);
        }

        private bool IsBoolChecked(SerializedProperty property)
        {
            SerializedProperty boolField = property.serializedObject.FindProperty(helpBoxAttribute.boolFieldName);

            return boolField != null && boolField.propertyType == SerializedPropertyType.Boolean &&
                   boolField.boolValue == helpBoxAttribute.expectedValue;
        }

        public float GetHelpBoxHeight()
        {
            return 2 > 0f ? 2 * 20 : EditorStyles.helpBox.CalcHeight(new GUIContent(helpBoxAttribute.text), EditorGUIUtility.currentViewWidth - 40f);
        }
    }
}