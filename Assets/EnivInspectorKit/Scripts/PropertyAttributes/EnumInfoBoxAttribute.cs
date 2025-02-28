namespace EnivStudios.EnivInspector
{
    public class EnumInfoBoxAttribute : EnivInspectorAttribute
    {
        public string message;
        public int spaceAbove;
        public int spaceBelow;
        public MessageType type;
        public string enumFieldName;
        public int[] displayIndices;
        public EnumInfoBoxAttribute(string message, int spaceAbove, int spaceBelow, MessageType type, string enumFieldName, params int[] displayIndices)
        {
            this.message = message;
            this.type = type;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
            this.enumFieldName = enumFieldName;
            this.displayIndices = displayIndices;
        }
    }
}