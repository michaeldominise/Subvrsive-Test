namespace EnivStudios.EnivInspector
{
    public class UpperInfoBoxAttribute : EnivInspectorAttribute 
    {
        public string message;
        public MessageType type;
        public float spaceAbove;
        public float spaceBelow;

        public UpperInfoBoxAttribute(string message, MessageType type, float spaceAbove, float spaceBelow)
        {
            this.message = message;
            this.type = type;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow * 1.95f;
        }
    }
}
