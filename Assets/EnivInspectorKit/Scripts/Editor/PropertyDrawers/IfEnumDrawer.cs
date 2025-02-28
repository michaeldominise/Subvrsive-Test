using UnityEngine;
using UnityEditor;
using System;
namespace EnivStudios.EnivInspector
{

    [CustomPropertyDrawer(typeof(IfEnumAttribute))]
    public class IfEnumDrawer : EnivInspectorDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            IfEnumAttribute attribute = (IfEnumAttribute)base.attribute;

            SerializedProperty enumField = property.serializedObject.FindProperty(attribute.enumFieldName);

            if (enumField != null && enumField.propertyType == SerializedPropertyType.Enum)
            {
                int enumIndex = enumField.enumValueIndex;

                // Check if the current enum index is in the list of display indices
                if (Array.IndexOf(attribute.displayIndices, enumIndex) == -1)
                {
                    return DefaultPropertyHeight(); // Don't draw the property if it should be hidden
                }
            }

            return EditorGUI.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowHideEnumProperty(position, property, label);
        }
    }
}