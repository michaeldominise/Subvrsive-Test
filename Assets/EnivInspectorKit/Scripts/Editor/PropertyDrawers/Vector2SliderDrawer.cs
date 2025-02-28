using UnityEditor;
using UnityEngine;

namespace EnivStudios.EnivInspector
{

    [CustomPropertyDrawer(typeof(Vector2SliderAttribute))]
    public class Vector2SliderDrawer : EnivInspectorDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.Vector2)
            {
                DrawSlider(position, property, label);
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }

    }
}