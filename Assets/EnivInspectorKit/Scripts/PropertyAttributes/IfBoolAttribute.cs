namespace EnivStudios.EnivInspector
{
    public class IfBoolAttribute : EnivInspectorAttribute
    {
        public string boolFieldName;
        public bool showProperty;

        public IfBoolAttribute(string boolFieldName, bool showProperty)
        {
            this.boolFieldName = boolFieldName;
            this.showProperty = showProperty;
        }
    }
}