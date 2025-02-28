using UnityEditor;
using UnityEngine;

namespace EnivStudios.EnivInspector
{
    [CustomPropertyDrawer(typeof(LowerInfoBoxAttribute))]
    public class LowerInfoBoxDrawer : EnivInspectorDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            LowerInfoBoxAttribute LowerInfoBoxAttribute = (LowerInfoBoxAttribute)attribute;

            // Calculate the height of the property field
            float propertyHeight = EditorGUI.GetPropertyHeight(property, label, true);

            // Calculate the total height (property field + HelpBox height + spacing below)
            float increasedHelpBoxHeight = EditorGUIUtility.singleLineHeight * 2.2f;
            float totalHeight = propertyHeight + increasedHelpBoxHeight + EditorGUIUtility.standardVerticalSpacing * LowerInfoBoxAttribute.spaceBelow + LowerInfoBoxAttribute.spaceBelow;

            // Add extra space above the property field
            totalHeight += EditorGUIUtility.standardVerticalSpacing * (LowerInfoBoxAttribute.spaceAbove * 2);

            return totalHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            LowerInfoBoxAttribute LowerInfoBoxAttribute = (LowerInfoBoxAttribute)attribute;

            DrawLowerInfoBox(position, LowerInfoBoxAttribute.message, LowerInfoBoxAttribute.type, 2.2f, LowerInfoBoxAttribute.spaceAbove, LowerInfoBoxAttribute.spaceBelow, property, label);

            // Draw the property field
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

}