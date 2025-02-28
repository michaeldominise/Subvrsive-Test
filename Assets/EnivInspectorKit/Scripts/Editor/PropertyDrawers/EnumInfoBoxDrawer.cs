using System;
using UnityEditor;
using UnityEngine;

namespace EnivStudios.EnivInspector
{
    [CustomPropertyDrawer(typeof(EnumInfoBoxAttribute))]
    public class EnumLowerInfoBoxDrawer : EnivInspectorDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EnumInfoBoxHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumInfoBoxAttribute helpBoxAttribute = (EnumInfoBoxAttribute)attribute;

            SerializedProperty enumField = property.serializedObject.FindProperty(helpBoxAttribute.enumFieldName);

            if (enumField != null && enumField.propertyType == SerializedPropertyType.Enum)
            {
                int enumIndex = enumField.enumValueIndex;

                // Check if the current enum index is in the list of display indices
                if (Array.IndexOf(helpBoxAttribute.displayIndices, enumIndex) == -1)
                {
                    // Don't draw the property if it should be hidden
                    return;
                }
            }

            InfoBoxPosition(position, property, label);

            // Draw the property field
            EditorGUI.PropertyField(position, property, label, true);
        }
    }
}