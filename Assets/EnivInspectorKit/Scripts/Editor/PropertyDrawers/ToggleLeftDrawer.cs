using UnityEditor;
using UnityEngine;
namespace EnivStudios.EnivInspector
{

    [CustomPropertyDrawer(typeof(ToggleLeftAttribute))]
    public class ToggleLeftDrawer : EnivInspectorDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ToggleLeftAttribute attribute = (ToggleLeftAttribute)base.attribute;

            if (attribute != null && IsSupportedPropertyType(property))
            {
                EditorGUI.BeginChangeCheck();

                bool newValue = EditorGUI.ToggleLeft(position, label, property.boolValue);

                if (EditorGUI.EndChangeCheck())
                {
                    property.boolValue = newValue;
                }
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }

        protected new bool IsSupportedPropertyType(SerializedProperty property)
        {
            return property.propertyType == SerializedPropertyType.Boolean;
        }
    }
}