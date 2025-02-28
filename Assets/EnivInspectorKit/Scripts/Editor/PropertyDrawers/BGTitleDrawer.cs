using UnityEditor;
using UnityEngine;

namespace EnivStudios.EnivInspector
{

    [CustomPropertyDrawer(typeof(BGTitleAttribute))]
    public class BGTitleDrawer : DecoratorDrawer
    {
        BGTitleAttribute bgTitleAttribute => attribute as BGTitleAttribute;

        public override void OnGUI(Rect position)
        {
            Color originalBackgroundColor = GUI.backgroundColor;

            // Add spacing above the title
            position.y += bgTitleAttribute.spaceAbove;

            Color backgroundColor = GetBackgroundColor();

            Rect boxRect = new Rect(position.x, position.y, position.width, bgTitleAttribute.BoxHeight);
            EditorGUI.DrawRect(boxRect, backgroundColor);

            // Draw the title label within the box
            GUIStyle titleStyle = new(GUI.skin.label)
            {
                alignment = bgTitleAttribute.CenterTitle ? TextAnchor.MiddleCenter : TextAnchor.MiddleLeft
            };

            // Set text color based on color scheme and editor theme
            titleStyle.normal.textColor = GetTextColor();
            titleStyle.fontSize = 11;

            EditorGUI.LabelField(boxRect, bgTitleAttribute.heading, titleStyle);

            // Reset the original background color
            GUI.backgroundColor = originalBackgroundColor;

            // Update position for the content below the box
            position.y += boxRect.height + bgTitleAttribute.spaceBelow; // Adjust position based on the box height
        }
        private Color GetBackgroundColor()
        {
            return bgTitleAttribute.colorScheme == EnivStudios.EnivInspector.ColorScheme.TextField ?
                EditorGUIUtility.isProSkin ? new Color(0.165f, 0.165f, 0.165f) : new Color(0.7f, 0.7f, 0.7f) :
                EditorGUIUtility.isProSkin ? new Color(0.29f, 0.29f, 0.29f) : new Color(0.9f, 0.9f, 0.9f);
        }

        private Color GetTextColor()
        {
            if (bgTitleAttribute.colorScheme == EnivStudios.EnivInspector.ColorScheme.TextField)
            {
                return EditorGUIUtility.isProSkin ? Color.white : Color.black;
            }
            else
            {
                return EditorGUIUtility.isProSkin ? Color.white : Color.black;
            }
        }
        public override float GetHeight()
        {
            // Add extra height for spacing above and below the title
            return bgTitleAttribute.BoxHeight + bgTitleAttribute.spaceAbove + bgTitleAttribute.spaceBelow;
        }
    }
}