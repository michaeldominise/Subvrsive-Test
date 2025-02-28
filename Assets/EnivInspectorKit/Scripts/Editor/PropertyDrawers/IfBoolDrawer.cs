using UnityEngine;
using UnityEditor;
namespace EnivStudios.EnivInspector
{

    [CustomPropertyDrawer(typeof(IfBoolAttribute))]
    public class IfBoolDrawer : EnivInspectorDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            // Get the IfBoolAttribute attached to the property
            IfBoolAttribute attribute = (IfBoolAttribute)base.attribute;

            // Check if the provided property is present in supported property types
            if (attribute != null && IsSupportedPropertyType(property))

            {
                SerializedProperty boolField = property.serializedObject.FindProperty(attribute.boolFieldName);

                // Check if the boolean property exists and matches the expected value
                if (boolField != null && boolField.propertyType == SerializedPropertyType.Boolean)
                {
                    bool currentValue = boolField.boolValue;

                    // If the boolean value doesn't match the expected value or bool is false, hide the property
                    if (currentValue != attribute.showProperty)
                    {
                        return DefaultPropertyHeight(); // Hide the property 
                    }
                }
            }
            // Return the default property height if not hidden
            return EditorGUI.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ShowHideBoolProperty(position, property, label);
        }
    }
}