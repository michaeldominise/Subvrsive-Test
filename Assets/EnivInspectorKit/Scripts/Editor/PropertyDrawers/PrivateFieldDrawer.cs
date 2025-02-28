using UnityEngine;
using UnityEditor;

namespace EnivStudios.EnivInspector
{
	[CustomPropertyDrawer(typeof(PrivateFieldAttribute))]
	public class PrivateFieldDrawer : EnivInspectorDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginDisabledGroup(true);
			EditorGUI.PropertyField(position, property, label);
			EditorGUI.EndDisabledGroup();
		}
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label);
		}
	}
}