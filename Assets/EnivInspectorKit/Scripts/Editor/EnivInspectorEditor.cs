using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EnivStudios.EnivInspector
{
    public static class SerializedPropertyExtensions
    {
        public static System.Type GetAttributeType(this SerializedProperty property)
        {
            var type = property.serializedObject.targetObject.GetType();
            var field = type.GetField(property.name);
            var attributes = field.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                if (attribute.GetType().IsSubclassOf(typeof(PropertyAttribute)))
                {
                    return attribute.GetType();
                }
            }

            return null;
        }
    }

    [CustomEditor(typeof(MonoBehaviour), true)]
    public class EnivInspectorEditor : Editor
    {
        private readonly Dictionary<string, List<SerializedProperty>> groupedProperties = new();
        private string[] tabNames;
        private int selectedTab;
        private void OnEnable()
        {
            InitializeProperties();

            var fields = target.GetType().GetFields();
            tabNames = fields
                .Where(f => Attribute.IsDefined(f, typeof(TabAttribute)))
                .Select(f => ((TabAttribute)Attribute.GetCustomAttribute(f, typeof(TabAttribute))).tabName)
                .Distinct()
                .ToArray();
        }

        private void InitializeProperties()
        {
            groupedProperties.Clear();

            var fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                var foldoutGroupAttributes = field.GetCustomAttributes(typeof(FoldoutGroupAttribute), true);
                var boxGroupAttributes = field.GetCustomAttributes(typeof(BoxGroupAttribute), true);
                if (boxGroupAttributes.Length > 0)
                {
                    var property = serializedObject.FindProperty(field.Name);
                    if (property != null)
                    {
                        var header = ((BoxGroupAttribute)boxGroupAttributes[0]).boxName;
                        AddPropertyField(header, property);
                    }
                }
                else if (foldoutGroupAttributes.Length > 0)
                {
                    var property = serializedObject.FindProperty(field.Name);
                    if (property != null)
                    {
                        var groupName = ((FoldoutGroupAttribute)foldoutGroupAttributes[0]).groupName;
                        AddPropertyField(groupName, property);
                    }
                }
            }
        }

        private void AddPropertyField(string groupName, SerializedProperty property)
        {
            if (!groupedProperties.ContainsKey(groupName))
            {
                groupedProperties[groupName] = new List<SerializedProperty>();
            }
            groupedProperties[groupName].Add(property);
        }

        private bool GetFoldoutState(string groupName)
        {
            string key = $"{target.GetType()}.{target.GetInstanceID()}.{groupName}";
            bool state = EditorPrefs.GetBool(key, true);
            return state;
        }

        private void SetFoldoutState(string groupName, bool state)
        {
            string key = $"{target.GetType()}.{target.GetInstanceID()}.{groupName}";
            EditorPrefs.SetBool(key, state);

        }
        protected T GetAttribute<T>(SerializedProperty property) where T : Attribute
        {
            var type = property.serializedObject.targetObject.GetType();
            var field = type.GetField(property.name);
            var attributes = field.GetCustomAttributes(typeof(T), true);

            if (attributes.Length > 0)
            {
                return (T)attributes[0];
            }

            return null;
        }

        /*  private void DrawPropertiesInFoldout(string groupName, List<SerializedProperty> properties, FoldoutGroupAttribute attribute)
          {
              float spaceAbove = 0f;
              float spaceBelow = 0f;

              if (attribute != null)
              {
                  spaceAbove = attribute.spaceAbove;
                  spaceBelow = attribute.spaceBelow;
              }

              EditorGUILayout.Space(spaceAbove);

              GUIStyle foldoutStyle = new GUIStyle(EditorStyles.foldout);
              foldoutStyle.margin = new RectOffset(14, 0, 2, 0); // Adjust the margin to move the arrow inside the help box

              EditorGUILayout.BeginVertical(EditorStyles.helpBox);

              bool foldoutState = GetFoldoutState(groupName);
              foldoutState = EditorGUILayout.BeginFoldoutHeaderGroup(foldoutState, groupName, foldoutStyle);
              SetFoldoutState(groupName, foldoutState);
              EditorGUILayout.EndFoldoutHeaderGroup();

              if (foldoutState)
              {
                  EditorGUI.indentLevel++; // Increase the indentation for properties inside the foldout

                  foreach (var property in properties)
                  {
                      EditorGUILayout.PropertyField(property);
                  }

                  EditorGUI.indentLevel--; // Reset the indentation
              }

              EditorGUILayout.EndVertical();

              EditorGUILayout.Space(spaceBelow);
          }*/

        //mitchky foldout
        private void DrawPropertiesInFoldout(string groupName, List<SerializedProperty> properties, FoldoutGroupAttribute attribute)
        {
            float spaceAbove = 0f;
            float spaceBelow = 0f;

            if (attribute != null)
            {
                spaceAbove = attribute.spaceAbove;
                spaceBelow = attribute.spaceBelow;
            }

            EditorGUILayout.Space(spaceAbove);

            GUIStyle foldoutStyle = new(EditorStyles.foldout)
            {
                margin = new RectOffset(14, 0, 2, 0) // Adjust the margin to move the arrow inside the help box
            };

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            bool foldoutState = GetFoldoutState(groupName);
            foldoutState = EditorGUILayout.BeginFoldoutHeaderGroup(foldoutState, groupName, foldoutStyle);
            SetFoldoutState(groupName, foldoutState);
            if (foldoutState)
            {
                EditorGUI.indentLevel++; // Increase the indentation for properties inside the foldout

                foreach (var property in properties)
                {
                    EditorGUILayout.BeginVertical(EditorStyles.helpBox); // Nested help box for each property field
                    EditorGUILayout.PropertyField(property);
                    EditorGUILayout.EndVertical();
                }

                EditorGUI.indentLevel--; // Reset the indentation
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(spaceBelow);
        }
        private void BoxGroupProperties(string header, List<SerializedProperty> properties, BoxGroupAttribute attribute)
        {
            float spaceAbove = 0f;
            float spaceBelow = 0f;

            if (attribute != null)
            {
                spaceAbove = attribute.spaceAbove;
                spaceBelow = attribute.spaceBelow;
            }

            EditorGUILayout.Space(spaceAbove);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            if (!string.IsNullOrEmpty(header))
            {
                GUILayout.Label(header, EditorStyles.boldLabel);
            }

            foreach (var property in properties)
            {
                EditorGUILayout.PropertyField(property);
            }
            GUILayout.Space(5);
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(spaceBelow);
        }
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            serializedObject.Update();

            InitializeProperties();

            foreach (var kvp in groupedProperties)
            {
                var attributeType = kvp.Value[0].GetAttributeType();
                if (attributeType == typeof(FoldoutGroupAttribute))
                {
                    var foldoutGroupAttribute = GetAttribute<FoldoutGroupAttribute>(kvp.Value[0]);
                    DrawPropertiesInFoldout(kvp.Key, kvp.Value, foldoutGroupAttribute);
                }

                else if (attributeType == typeof(BoxGroupAttribute))
                {
                    var boxGroupAttribute = GetAttribute<BoxGroupAttribute>(kvp.Value[0]);
                    BoxGroupProperties(kvp.Key, kvp.Value, boxGroupAttribute);

                }
            }

            if (tabNames.Length > 0)
            {
                TabAttribute selectedTabAttribute = GetTabAttribute(tabNames[selectedTab]);
                float spaceAbove = selectedTabAttribute != null ? selectedTabAttribute.spaceAbove : 0f;
                float spaceBelow = selectedTabAttribute != null ? selectedTabAttribute.spaceBelow : 0f;

                GUILayout.Space(spaceAbove);
                GUILayout.BeginVertical("HelpBox");
                // GUILayout.Space(5);
                DrawTabs();
                DrawTabFields(tabNames[selectedTab]);
                GUILayout.Space(5);
                GUILayout.EndVertical();
                GUILayout.Space(spaceBelow);
            }

            serializedObject.ApplyModifiedProperties();
        }
        private void DrawTabs()
        {
            selectedTab = GUILayout.Toolbar(selectedTab, tabNames);
        }
        private void DrawTabFields(string tabName)
        {
            GUILayout.Space(10);
            var fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                var boxGroupAttribute = (BoxGroupAttribute)Attribute.GetCustomAttribute(field, typeof(BoxGroupAttribute));
                var foldoutGroupAttribute = (FoldoutGroupAttribute)Attribute.GetCustomAttribute(field, typeof(FoldoutGroupAttribute));
                var tabAttribute = (TabAttribute)Attribute.GetCustomAttribute(field, typeof(TabAttribute));

                if ((boxGroupAttribute != null && boxGroupAttribute.boxName == tabName) ||
                    (foldoutGroupAttribute != null && foldoutGroupAttribute.groupName == tabName) ||
                    (tabAttribute != null && tabAttribute.tabName == tabName))
                {
                    EditorGUILayout.PropertyField(serializedObject.FindProperty(field.Name), true);
                }
            }
        }
        private TabAttribute GetTabAttribute(string tabName)
        {
            var fields = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                var tabAttribute = (TabAttribute)Attribute.GetCustomAttribute(field, typeof(TabAttribute));

                if (tabAttribute != null && tabAttribute.tabName == tabName)
                {
                    return tabAttribute;
                }
            }

            return null;
        }
    }
}