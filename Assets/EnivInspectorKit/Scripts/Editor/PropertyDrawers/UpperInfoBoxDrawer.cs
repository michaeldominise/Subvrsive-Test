using UnityEngine;
using UnityEditor;
namespace EnivStudios.EnivInspector
{

    [CustomPropertyDrawer(typeof(UpperInfoBoxAttribute))]
    public class UpperInfoBoxDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            float fixedHeight = 2;
            UpperInfoBoxAttribute upperInfoBoxAttribute = (UpperInfoBoxAttribute)attribute;
            if (fixedHeight > 0)
            {
                return (2 * 20) + upperInfoBoxAttribute.spaceAbove + upperInfoBoxAttribute.spaceBelow;
            }

            GUIContent content = new GUIContent(upperInfoBoxAttribute.message);
            float height = EditorStyles.helpBox.CalcHeight(content, EditorGUIUtility.currentViewWidth - 40f);
            return Mathf.Max(2f, height + 4f + upperInfoBoxAttribute.spaceAbove + upperInfoBoxAttribute.spaceBelow);
        }

        public override void OnGUI(Rect position)
        {
            UpperInfoBoxAttribute helpBoxAttribute = (UpperInfoBoxAttribute)attribute;

            Rect helpBoxRect = new(position.x, position.y + helpBoxAttribute.spaceAbove, position.width, position.height - helpBoxAttribute.spaceAbove - helpBoxAttribute.spaceBelow);
            EditorGUI.HelpBox(helpBoxRect, helpBoxAttribute.message, (UnityEditor.MessageType)helpBoxAttribute.type);
        }
    }
}