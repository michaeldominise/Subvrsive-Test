using UnityEditor;
using UnityEngine;
namespace EnivStudios.EnivInspector
{

    [CustomPropertyDrawer(typeof(RestrictedFieldAttribute))]
    public class RestrictedFieldDrawer : EnivInspectorDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RestrictField(position, property, label);
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }
    }
}