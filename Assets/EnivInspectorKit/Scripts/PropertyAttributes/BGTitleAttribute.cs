namespace EnivStudios.EnivInspector
{
    public enum ColorScheme
    {
        TextField,
        InfoBox
    }

    public class BGTitleAttribute : EnivInspectorAttribute
    {
        public string heading;
        public bool CenterTitle;
        public ColorScheme colorScheme;
        public float spaceAbove; 
        public float spaceBelow; 
        public float BoxHeight;

        public BGTitleAttribute(string heading = "Eniv Inspector", ColorScheme colorScheme = ColorScheme.InfoBox, bool centerTitle = false, float spaceAbove = 0f, float spaceBelow = 0f, float boxHeight = 2.2f)
        {
            this.heading = heading;
            this.colorScheme = colorScheme;
            this.CenterTitle = centerTitle;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow + 3f;
            this.BoxHeight = boxHeight * 10;
        }
    }
}
