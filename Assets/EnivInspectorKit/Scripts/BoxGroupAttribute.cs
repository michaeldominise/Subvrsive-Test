namespace EnivStudios.EnivInspector
{
    public class BoxGroupAttribute : EnivInspectorAttribute
    {
        public string boxName;
        public float spaceAbove;
        public float spaceBelow;

        public BoxGroupAttribute(string boxName, float spaceAbove = 0f, float spaceBelow = 0f)
        {
            this.boxName = boxName;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
        }
    }
}