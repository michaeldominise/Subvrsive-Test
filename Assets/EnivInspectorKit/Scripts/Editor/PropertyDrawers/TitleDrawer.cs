using UnityEngine;
using UnityEditor;
namespace EnivStudios.EnivInspector
{

    [CustomPropertyDrawer(typeof(TitleAttribute))]
    public class TitleDrawer : EnivInspectorDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            TitleAttribute titleAttribute = attribute as TitleAttribute;

            if (string.IsNullOrEmpty(titleAttribute.heading))
            {
                DrawLineOnly(position, titleAttribute.spaceAbove, titleAttribute.spaceBelow, titleAttribute.lineColor);
            }
            else
            {
                DrawTitleWithLine(position, titleAttribute.heading, titleAttribute.spaceAbove, titleAttribute.HeadingColor, titleAttribute.lineColor);
            }

            // Draw property field below the title and lines with spacing below
            EditorGUI.PropertyField(new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + titleAttribute.spaceAbove + titleAttribute.spaceBelow, position.width, EditorGUIUtility.singleLineHeight), property, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            TitleAttribute titleAttribute = attribute as TitleAttribute;

            return EditorGUIUtility.singleLineHeight * 2 + titleAttribute.spaceAbove + titleAttribute.spaceBelow; // Adjusted height with spacing
        }
    }
}