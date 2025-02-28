using System;
using UnityEditor;
using UnityEngine;

namespace EnivStudios.EnivInspector
{
    public class EnivInspectorDrawer : PropertyDrawer
    {
        #region ImageAttributeProperties
        protected Texture2D LoadImage(string imagePath)
        {
            return AssetDatabase.LoadAssetAtPath<Texture2D>(imagePath);
        }
        protected void DrawImage(Rect position, string imagePath, float height, float spaceAbove, float spaceBelow)
        {
            Texture2D customBgTexture = LoadImage(imagePath);
            if (customBgTexture != null)
            {
                GUIStyle backgroundImageStyle = new();
                backgroundImageStyle.normal.background = customBgTexture;

                // Draw space above the image
                Rect spaceAboveRect = new(position.x, position.y, position.width, spaceAbove);
                EditorGUI.LabelField(spaceAboveRect, GUIContent.none);

                // Draw the image
                Rect textureBackgroundPosition = new(position.x, position.y + spaceAbove, position.width, height);
                EditorGUI.LabelField(textureBackgroundPosition, GUIContent.none, backgroundImageStyle);

                // Draw space below the image
                Rect spaceBelowRect = new(position.x, position.y + height + spaceAbove, position.width, spaceBelow);
                EditorGUI.LabelField(spaceBelowRect, GUIContent.none);
            }
        }
        #endregion

        #region IfBoolAttributeProperties
        protected void ShowHideBoolProperty(Rect position, SerializedProperty property, GUIContent label)
        {
            // Get theIfBoolAttribute attached to the property
            IfBoolAttribute attribute = (IfBoolAttribute)base.attribute;

            // Check if the provided property is present in supported property types
            if (attribute != null && IsSupportedPropertyType(property))
            {
                SerializedProperty boolField = property.serializedObject.FindProperty(attribute.boolFieldName);

                // Check if the boolean property exists and matches the expected value
                if (boolField != null && boolField.propertyType == SerializedPropertyType.Boolean)
                {
                    bool currentValue = boolField.boolValue;

                    // If the boolean value doesn't match the expected value or bool is false, hide the property
                    if (currentValue != attribute.showProperty)
                    {
                        return;// Don't draw property it should be hidden
                    }
                }
            }
            // Draw the property using EditorGUI.Property Field
            EditorGUI.PropertyField(position, property, label);
        }
        protected bool IsSupportedPropertyType(SerializedProperty property)
        {
            SerializedPropertyType[] supportedTypes = new SerializedPropertyType[] {
            SerializedPropertyType.Generic, SerializedPropertyType.Integer,SerializedPropertyType.Boolean,SerializedPropertyType.Float,
            SerializedPropertyType.String,SerializedPropertyType.Color,SerializedPropertyType.ObjectReference,SerializedPropertyType.LayerMask,
            SerializedPropertyType.Enum,SerializedPropertyType.Vector2,SerializedPropertyType.Vector3,SerializedPropertyType.Vector4,SerializedPropertyType.Rect,
            SerializedPropertyType.ArraySize,SerializedPropertyType.Character,SerializedPropertyType.AnimationCurve,SerializedPropertyType.Bounds, SerializedPropertyType.Quaternion,
            SerializedPropertyType.ExposedReference,SerializedPropertyType.FixedBufferSize,SerializedPropertyType.Vector2Int,SerializedPropertyType.Vector3Int,SerializedPropertyType.RectInt,
            SerializedPropertyType.BoundsInt,
        };

            return Array.IndexOf(supportedTypes, property.propertyType) != -1;
        }
        #endregion

        #region IfEnumAttributeProperties
        protected void ShowHideEnumProperty(Rect position, SerializedProperty property, GUIContent label)
        {
            IfEnumAttribute attribute = (IfEnumAttribute)base.attribute;

            SerializedProperty enumField = property.serializedObject.FindProperty(attribute.enumFieldName);

            if (enumField != null && enumField.propertyType == SerializedPropertyType.Enum)
            {
                int enumIndex = enumField.enumValueIndex;

                // Check if the current enum index is in the list of display indices
                if (Array.IndexOf(attribute.displayIndices, enumIndex) == -1)
                {
                    return; // Don't draw the property if it should be hidden
                }
            }

            EditorGUI.PropertyField(position, property, label, true);
        }
        #endregion

        #region LowerInfoBoxAttributeProperties
        protected void DrawLowerInfoBox(Rect position, string message, EnivStudios.EnivInspector.MessageType type, float height, float spaceAbove, float spaceBelow, SerializedProperty property, GUIContent label)
        {
            // Calculate the position for the HelpBox below the property field
            Rect helpBoxPositionBelow = new(position.x, position.y + EditorGUI.GetPropertyHeight(property, label, true) + EditorGUIUtility.standardVerticalSpacing * (spaceAbove * 2), position.width, EditorGUIUtility.singleLineHeight * height);

            // Draw the HelpBox below the property field
            EditorGUI.HelpBox(helpBoxPositionBelow, message, (UnityEditor.MessageType)type);
        }
        #endregion

        #region TitleAttribute
        protected void DrawLineOnly(Rect position, float spaceAbove, float spaceBelow, CommonColors lineColor)
        {
            Handles.color = GetColorFromEnum(lineColor);
            // Draw a single line if the title is null or empty
            Handles.DrawLine(new Vector3(position.x, position.y + EditorGUIUtility.singleLineHeight / 2 + spaceAbove, 0),
                             new Vector3(position.x + position.width, position.y + EditorGUIUtility.singleLineHeight / 2 + spaceAbove, 0));
            Handles.color = Color.white; // Reset color to default
        }

        protected void DrawTitleWithLine(Rect position, string heading, float spaceAbove, Color headingColor, CommonColors lineColor)
        {
            float titleWidth = EditorStyles.boldLabel.CalcSize(new GUIContent(heading)).x;

            // Add space from both sides of the title
            float spaceFromSides = 5f;

            // Calculate the center position for the title
            float titleCenterX = position.x + (position.width - titleWidth - 2 * spaceFromSides) / 2 + spaceFromSides;

            // Draw line from left to center of title with spacing above
            Handles.color = GetColorFromEnum(lineColor);
            Handles.DrawLine(new Vector3(position.x, position.y + EditorGUIUtility.singleLineHeight / 2 + spaceAbove, 0),
                             new Vector3(titleCenterX, position.y + EditorGUIUtility.singleLineHeight / 2 + spaceAbove, 0));

            // Set GUI content color for the label
            Color originalContentColor = GUI.contentColor;
            GUI.contentColor = headingColor;

            // Draw title with specified heading color and spacing above
            EditorGUI.LabelField(new Rect(titleCenterX, position.y + spaceAbove, titleWidth, EditorGUIUtility.singleLineHeight),
                                 heading, EditorStyles.boldLabel);

            // Reset GUI content color
            GUI.contentColor = originalContentColor;

            // Draw line from right of title to the end with spacing below
            Handles.color = GetColorFromEnum(lineColor);
            Handles.DrawLine(new Vector3(titleCenterX + titleWidth + 4, position.y + EditorGUIUtility.singleLineHeight / 2 + spaceAbove, 0),
                             new Vector3(position.x + position.width, position.y + EditorGUIUtility.singleLineHeight / 2 + spaceAbove, 0));

            Handles.color = Color.white;
        }
        #endregion

        #region RestrictedFieldAttribute
        protected void RestrictField(Rect position, SerializedProperty property, GUIContent label)
        {
            RestrictedFieldAttribute restrictedFieldAttribute = attribute as RestrictedFieldAttribute;

            SerializedProperty conditionalBool = property.serializedObject.FindProperty(restrictedFieldAttribute.boolFieldName);

            if (conditionalBool != null && conditionalBool.propertyType == SerializedPropertyType.Boolean)
            {
                EditorGUI.BeginDisabledGroup(!conditionalBool.boolValue);
                EditorGUI.PropertyField(position, property, label);
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }
        #endregion

        #region Vector2Slider Attribute
        protected void DrawSlider(Rect position, SerializedProperty property, GUIContent label)
        {

            EditorGUI.BeginProperty(position, label, property);

            Vector2 vectorValue = property.vector2Value;
            float minLimit = ((Vector2SliderAttribute)attribute).xValue;
            float maxLimit = ((Vector2SliderAttribute)attribute).yValue;

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            float fieldWidth = position.width / 4f;
            float sliderWidth = position.width - 2 * fieldWidth - 10f; // Adjusted width here
            float sliderX = position.x + fieldWidth + 5f; // Adjusted position here

            Rect xRect = new Rect(position.x, position.y, fieldWidth, position.height);
            Rect sliderRect = new Rect(sliderX, position.y, sliderWidth, position.height);
            Rect yRect = new Rect(position.x + position.width - fieldWidth, position.y, fieldWidth, position.height);

            EditorGUI.LabelField(xRect, "X");

            // Track changes in X input field
            EditorGUI.BeginChangeCheck();
            vectorValue.x = EditorGUI.FloatField(xRect, Mathf.Round(vectorValue.x * 100) / 100);
            if (EditorGUI.EndChangeCheck())
            {
                // X value changed, update slider
                vectorValue.x = Mathf.Clamp(vectorValue.x, minLimit, maxLimit);
                vectorValue.y = Mathf.Clamp(vectorValue.y, minLimit, maxLimit);
            }

            EditorGUI.MinMaxSlider(sliderRect, ref vectorValue.x, ref vectorValue.y, minLimit, maxLimit);

            EditorGUI.LabelField(yRect, "Y");

            // Track changes in Y input field
            EditorGUI.BeginChangeCheck();
            vectorValue.y = EditorGUI.FloatField(yRect, Mathf.Round(vectorValue.y * 100) / 100);
            if (EditorGUI.EndChangeCheck())
            {
                // Y value changed, update slider
                vectorValue.x = Mathf.Clamp(vectorValue.x, minLimit, maxLimit);
                vectorValue.y = Mathf.Clamp(vectorValue.y, minLimit, maxLimit);
            }

            property.vector2Value = vectorValue;

            EditorGUI.EndProperty();
        }
        #endregion

        #region ButtonAttribute
        protected void DrawButton(Rect position, SerializedProperty property, GUIContent label)
        {
            // Draw the button in the Inspector with spaceAbove and spaceBelow
            Rect buttonPosition = new(position.x, position.y + ((ButtonAttribute)attribute).spaceAbove, position.width, EditorGUIUtility.singleLineHeight);

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

            // Customize the label font size and button size
            buttonStyle.fontSize = ((ButtonAttribute)attribute).labelFontSize;
            buttonStyle.fixedHeight = ((ButtonAttribute)attribute).buttonSize;

            if (GUI.Button(buttonPosition, label.text,buttonStyle))
            {
                // Get the method name from the ButtonAttribute
                ButtonAttribute buttonAttribute = attribute as ButtonAttribute;
                string methodName = buttonAttribute.methodName;

                // Invoke the method using reflection
                System.Reflection.MethodInfo method = property.serializedObject.targetObject.GetType().GetMethod(methodName);
                if (method != null && Event.current.button == 0)
                {
                    _ = method.Invoke(property.serializedObject.targetObject, null);
                }
            }
        }
        #endregion

        #region IconTitleAttribute
        protected void DrawIcon(Rect position,SerializedProperty property ,IconTitleAttribute iconTitleAttribute)
        {
            Texture2D icon = AssetDatabase.LoadAssetAtPath<Texture2D>(iconTitleAttribute.iconPath);
            if (icon != null)
            {
                Rect iconRect = new(position.x, position.y + 1.8f + iconTitleAttribute.spaceAbove, 16, 16);
                Rect labelRect = new(position.x + 20, position.y + iconTitleAttribute.spaceAbove, position.width - 20, EditorGUIUtility.singleLineHeight);

                GUIStyle labelStyle = new(EditorStyles.boldLabel)
                {
                    fontSize = 13
                };
                GUI.DrawTexture(iconRect, icon);
                EditorGUI.LabelField(labelRect, new GUIContent(property.displayName), labelStyle);
            }
            else
            {
                EditorGUI.LabelField(position, "Icon not found at: " + iconTitleAttribute.iconPath);
            }
        }
        #endregion

        #region EnumInfoBoxAttribute
        protected float EnumInfoBoxHeight(SerializedProperty property, GUIContent label)
        {
            EnumInfoBoxAttribute InfoBoxAttribute = (EnumInfoBoxAttribute)attribute;

            SerializedProperty enumField = property.serializedObject.FindProperty(InfoBoxAttribute.enumFieldName);

            if (enumField != null && enumField.propertyType == SerializedPropertyType.Enum)
            {
                int enumIndex = enumField.enumValueIndex;

                // Check if the current enum index is in the list of display indices
                if (Array.IndexOf(InfoBoxAttribute.displayIndices, enumIndex) == -1)
                {
                    // Don't draw the property if it should be hidden
                    return 0f;
                }
            }

            // Calculate the height of the property field
            float propertyHeight = EditorGUI.GetPropertyHeight(property, label, true);

            // Calculate the total height (property field + HelpBox height + spacing below)
            float increasedHelpBoxHeight = EditorGUIUtility.singleLineHeight * 2;
            float totalHeight = propertyHeight + increasedHelpBoxHeight + EditorGUIUtility.standardVerticalSpacing * InfoBoxAttribute.spaceBelow + InfoBoxAttribute.spaceBelow;

            // Add extra space above the property field
            totalHeight += EditorGUIUtility.standardVerticalSpacing * (InfoBoxAttribute.spaceAbove * 2);

            return totalHeight;
        }

        protected void InfoBoxPosition(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumInfoBoxAttribute helpBoxAttribute = (EnumInfoBoxAttribute)attribute;
            // Calculate the position for the HelpBox below the property field
            Rect helpBoxPositionBelow = new(position.x, position.y + EditorGUI.GetPropertyHeight(property, label, true) + EditorGUIUtility.standardVerticalSpacing * (helpBoxAttribute.spaceAbove * 2), position.width, EditorGUIUtility.singleLineHeight * 2);

            // Draw the HelpBox below the property field
            EditorGUI.HelpBox(helpBoxPositionBelow, helpBoxAttribute.message, (UnityEditor.MessageType)helpBoxAttribute.type);

        }
        #endregion
        protected float DefaultPropertyHeight()
        {
            return -1.8f;
        }
        private Color GetColorFromEnum(CommonColors colorEnum)
        {
            return colorEnum switch
            {
                CommonColors.Red => Color.red,
                CommonColors.Green => Color.green,
                CommonColors.Blue => Color.blue,
                CommonColors.Yellow => Color.yellow,
                CommonColors.White => Color.white,
                CommonColors.Black => Color.black,
                CommonColors.Orange => new Color(1.0f, 0.647f, 0.0f),// RGB for orange
                CommonColors.Purple => new Color(0.502f, 0.0f, 0.502f),// RGB for purple
                CommonColors.Pink => new Color(1.0f, 0.753f, 0.796f),// RGB for pink
                CommonColors.Brown => new Color(0.647f, 0.165f, 0.165f),// RGB for brown
                CommonColors.Cyan => Color.cyan,
                CommonColors.Magenta => Color.magenta,
                CommonColors.Lime => new Color(0.0f, 1.0f, 0.0f),// RGB for lime
                CommonColors.Teal => new Color(0.0f, 0.502f, 0.502f),// RGB for teal
                CommonColors.Indigo => new Color(0.294f, 0.0f, 0.51f),// RGB for indigo
                CommonColors.Maroon => new Color(0.502f, 0.0f, 0.0f),// RGB for maroon
                CommonColors.Olive => new Color(0.502f, 0.502f, 0.0f),// RGB for olive
                CommonColors.Navy => new Color(0.0f, 0.0f, 0.502f),// RGB for navy
                CommonColors.Fuchsia => new Color(1.0f, 0.0f, 1.0f),// RGB for fuchsia
                CommonColors.Silver => new Color(0.753f, 0.753f, 0.753f),// RGB for silver
                CommonColors.Gray => Color.gray,
                CommonColors.Aqua => new Color(0.0f, 1.0f, 1.0f),// RGB for aqua
                CommonColors.DarkRed => new Color(0.545f, 0.0f, 0.0f),// RGB for dark red
                CommonColors.DarkGreen => new Color(0.0f, 0.392f, 0.0f),// RGB for dark green
                CommonColors.DarkBlue => new Color(0.0f, 0.0f, 0.545f),// RGB for dark blue
                CommonColors.DarkYellow => new Color(0.545f, 0.545f, 0.0f),// RGB for dark yellow
                CommonColors.DarkGray => new Color(0.663f, 0.663f, 0.663f),// RGB for dark gray
                CommonColors.LightGray => new Color(0.827f, 0.827f, 0.827f),// RGB for light gray
                CommonColors.Transparent => new Color(0.0f, 0.0f, 0.0f, 0.0f),// Fully transparent
                _ => Color.white,
            };
        }
    }
}
