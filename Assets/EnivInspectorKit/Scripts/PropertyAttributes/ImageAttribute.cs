namespace EnivStudios.EnivInspector
{ 
    public class ImageAttribute : EnivInspectorAttribute
    {
        public string imagePath;
        public float imageHeight;
        public float spaceAbove;
        public float spaceBelow;

        public ImageAttribute(string imagePath, float imageHeight, float spaceAbove, float spaceBelow)
        {
            this.imagePath = imagePath;
            this.imageHeight = imageHeight;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
        }
    }
}
