using UnityEngine;
using UnityEditor;

namespace EnivStudios.EnivInspector
{
    [CustomPropertyDrawer(typeof(IconTitleAttribute))]
    public class IconTitleDrawer : EnivInspectorDrawer
    {
        // Override the OnGUI method to customize the drawing of the property
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Check if the attribute is valid
            if (attribute is IconTitleAttribute iconTitleAttribute)
            {
                DrawIcon(position, property, iconTitleAttribute);
            }
            else
            {
                EditorGUI.LabelField(position, "Invalid IconTitleAttribute");
            }
        }

        // Override the GetPropertyHeight method to specify the height of the property drawer
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            IconTitleAttribute attribute = (IconTitleAttribute)this.attribute;
            return EditorGUIUtility.singleLineHeight + attribute.spaceAbove + attribute.spaceBelow;
        }

    }
}