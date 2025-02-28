using UnityEditor;
using UnityEngine;
namespace EnivStudios.EnivInspector
{

    [CustomPropertyDrawer(typeof(ImageAttribute))]
    public class ImageDrawer : EnivInspectorDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            ImageAttribute image = (ImageAttribute)attribute;

            // Add space above and below the image
            return image.imageHeight + EditorGUI.GetPropertyHeight(property, label) + image.spaceAbove + image.spaceBelow;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ImageAttribute image = (ImageAttribute)attribute;

            //Draw Image
            DrawImage(position, image.imagePath, image.imageHeight, image.spaceAbove, image.spaceBelow);

            // Draw the property field below the image
            Rect propPosition = new(position.x, position.y + image.imageHeight + image.spaceAbove + image.spaceBelow, position.width, EditorGUI.GetPropertyHeight(property, label));
            EditorGUI.PropertyField(propPosition, property, label);
        }
    }

}