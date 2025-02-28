using UnityEngine;

namespace EnivStudios.EnivInspector
{
    public enum CommonColors
    {
        Red,
        Green,
        Blue,
        Yellow,
        White,
        Black,
        Orange,
        Purple,
        Pink,
        Brown,
        Cyan,
        Magenta,
        Lime,
        Teal,
        Indigo,
        Maroon,
        Olive,
        Navy,
        Fuchsia,
        Silver,
        Gray,
        Aqua,
        DarkRed,
        DarkGreen,
        DarkBlue,
        DarkYellow,
        DarkGray,
        LightGray,
        Transparent,
    }


    public class TitleAttribute : EnivInspectorAttribute
    {
        public string heading;
        public float spaceAbove;
        public float spaceBelow;
        public CommonColors lineColor;
        public CommonColors headingColor;
        public Color LineColor
        {
            get { return GetColorFromEnum(lineColor); }
        }
        public Color HeadingColor
        {
            get { return GetColorFromEnum(headingColor); }
        }


        public TitleAttribute(string heading, float spaceAbove, float spaceBelow, CommonColors lineColor = CommonColors.White, CommonColors headingColor = CommonColors.White)
        {
            this.heading = heading;
            this.spaceAbove = spaceAbove;
            this.spaceBelow = spaceBelow;
            this.lineColor = lineColor;
            this.headingColor = headingColor;
        }
        private Color GetColorFromEnum(CommonColors colorEnum)
        {
            return colorEnum switch
            {
                CommonColors.Red => Color.red,
                CommonColors.Green => Color.green,
                CommonColors.Blue => Color.blue,
                CommonColors.Yellow => Color.yellow,
                CommonColors.White => Color.white,
                CommonColors.Black => Color.black,
                CommonColors.Orange => new Color(1.0f, 0.647f, 0.0f),// RGB for orange
                CommonColors.Purple => new Color(0.502f, 0.0f, 0.502f),// RGB for purple
                CommonColors.Pink => new Color(1.0f, 0.753f, 0.796f),// RGB for pink
                CommonColors.Brown => new Color(0.647f, 0.165f, 0.165f),// RGB for brown
                CommonColors.Cyan => Color.cyan,
                CommonColors.Magenta => Color.magenta,
                CommonColors.Lime => new Color(0.0f, 1.0f, 0.0f),// RGB for lime
                CommonColors.Teal => new Color(0.0f, 0.502f, 0.502f),// RGB for teal
                CommonColors.Indigo => new Color(0.294f, 0.0f, 0.51f),// RGB for indigo
                CommonColors.Maroon => new Color(0.502f, 0.0f, 0.0f),// RGB for maroon
                CommonColors.Olive => new Color(0.502f, 0.502f, 0.0f),// RGB for olive
                CommonColors.Navy => new Color(0.0f, 0.0f, 0.502f),// RGB for navy
                CommonColors.Fuchsia => new Color(1.0f, 0.0f, 1.0f),// RGB for fuchsia
                CommonColors.Silver => new Color(0.753f, 0.753f, 0.753f),// RGB for silver
                CommonColors.Gray => Color.gray,
                CommonColors.Aqua => new Color(0.0f, 1.0f, 1.0f),// RGB for aqua
                CommonColors.DarkRed => new Color(0.545f, 0.0f, 0.0f),// RGB for dark red
                CommonColors.DarkGreen => new Color(0.0f, 0.392f, 0.0f),// RGB for dark green
                CommonColors.DarkBlue => new Color(0.0f, 0.0f, 0.545f),// RGB for dark blue
                CommonColors.DarkYellow => new Color(0.545f, 0.545f, 0.0f),// RGB for dark yellow
                CommonColors.DarkGray => new Color(0.663f, 0.663f, 0.663f),// RGB for dark gray
                CommonColors.LightGray => new Color(0.827f, 0.827f, 0.827f),// RGB for light gray
                CommonColors.Transparent => new Color(0.0f, 0.0f, 0.0f, 0.0f),// Fully transparent
                _ => Color.white,
            };
        }
    }
}