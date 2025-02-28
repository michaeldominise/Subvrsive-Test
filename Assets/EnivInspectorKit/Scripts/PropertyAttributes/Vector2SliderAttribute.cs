namespace EnivStudios.EnivInspector
{
    public class Vector2SliderAttribute : EnivInspectorAttribute
    {
        public float xValue;
        public float yValue;
        public Vector2SliderAttribute(float xValue = 0f, float yValue = 0f)
        {
            this.xValue = xValue;
            this.yValue = yValue;
        }
    }
}
