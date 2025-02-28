namespace EnivStudios.EnivInspector
{
    public class IconTitleAttribute : EnivInspectorAttribute
    {
        public readonly string iconPath;
        public readonly float spaceAbove;
        public readonly float spaceBelow;
        // Constructor to initialize the icon and title parameters
        public IconTitleAttribute(string iconPath, float spaceAbove = 0f, float spaceBelow = 0f)
        {
            this.iconPath = iconPath;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
        }
    }
}