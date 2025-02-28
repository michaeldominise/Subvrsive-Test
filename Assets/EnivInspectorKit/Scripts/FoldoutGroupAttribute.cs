namespace EnivStudios.EnivInspector
{
    public class FoldoutGroupAttribute : EnivInspectorAttribute
    { 
        public string groupName;
        public float spaceAbove;
        public float spaceBelow;

        public FoldoutGroupAttribute(string groupName, float spaceAbove = 0f, float spaceBelow = 0f)
        {
            this.groupName = groupName;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
        }
    }
}