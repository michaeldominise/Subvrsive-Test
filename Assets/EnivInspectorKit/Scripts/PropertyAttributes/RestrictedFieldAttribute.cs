namespace EnivStudios.EnivInspector
{
    public class RestrictedFieldAttribute : EnivInspectorAttribute
    {
        public string boolFieldName;
        public RestrictedFieldAttribute(string boolFieldName)
        {
            this.boolFieldName = boolFieldName;
        }

    }
}
