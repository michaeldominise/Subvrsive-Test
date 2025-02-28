using UnityEngine;

namespace EnivStudios.EnivInspector
{
    public class ButtonAttribute : EnivInspectorAttribute
    {
        public string methodName;
        public int labelFontSize;
        public float buttonSize;
        public float spaceAbove;
        public float spaceBelow;
        public ButtonAttribute(string methodName, int labelFontSize = 13, float buttonSize = 18f ,float spaceAbove = 0f, float spaceBelow = 0f)
        {
            this.methodName = methodName;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
            this.labelFontSize = labelFontSize;
            this.buttonSize = buttonSize;
        }
    }

}