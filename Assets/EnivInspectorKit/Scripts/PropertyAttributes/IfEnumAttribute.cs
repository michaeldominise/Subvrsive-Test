namespace EnivStudios.EnivInspector
{
    public class IfEnumAttribute : EnivInspectorAttribute
    {
        public string enumFieldName;
        public int[] displayIndices;
        public IfEnumAttribute(string enumFieldName, params int[] displayIndices)
        {
            this.enumFieldName = enumFieldName;
            this.displayIndices = displayIndices;
        }
    }
}
