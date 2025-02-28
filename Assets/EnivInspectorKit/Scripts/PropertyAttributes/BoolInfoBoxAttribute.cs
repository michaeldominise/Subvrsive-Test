using UnityEditor;
using UnityEngine;

namespace EnivStudios.EnivInspector
{
    public class BoolInfoBoxAttribute : EnivInspectorAttribute
    {
        public readonly string text;
        public float spaceAbove;
        public float spaceBelow;
        public readonly MessageType messageType;
        public readonly string boolFieldName;
        public readonly bool expectedValue;

        public BoolInfoBoxAttribute(string text, string boolFieldName, bool expectedValue, float spaceAbove = 0f, float spaceBelow = 0f, MessageType messageType = MessageType.Info)
        {
            this.text = text;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
            this.messageType = messageType;
            this.boolFieldName = boolFieldName;
            this.expectedValue = expectedValue;
        }
    }
}