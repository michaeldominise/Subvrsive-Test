
namespace EnivStudios.EnivInspector
{
    public enum MessageType
    {
        Info = 1,
        Warning = 2,
        Error = 3
    }
    public class LowerInfoBoxAttribute : EnivInspectorAttribute
    {

        public string message;
        public MessageType type;
        public float spaceAbove;
        public float spaceBelow;
        public LowerInfoBoxAttribute(string message, MessageType type, float spaceAbove, float spaceBelow)
        {
            this.message = message;
            this.type = type;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
        }
    }
}
