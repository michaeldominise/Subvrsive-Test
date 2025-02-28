namespace EnivStudios.EnivInspector
{
    public class TabAttribute : EnivInspectorAttribute
    {
        public string tabName;
        public float spaceAbove;
        public float spaceBelow;

        public TabAttribute(string tabName, float spaceAbove = 0f, float spaceBelow = 0f)
        {
            this.tabName = tabName;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
        }
    }
}
