namespace EnivStudios.EnivInspector
{
    public class NameAttribute : EnivInspectorAttribute
    {
        public string label;
        public NameAttribute(string label)
        {
            this.label = label;
        }
    }
}
