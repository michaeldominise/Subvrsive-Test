using UnityEngine;
namespace EnivStudios.EnivInspector
{
    public class Title : MonoBehaviour
    {
        [Title(null, spaceAbove: 8f, spaceBelow: 8f, lineColor: CommonColors.White)]
        public int someVar_1;
        public int someVar_2;
        public int someVar_3;

        [Title("Simple Title", spaceAbove: 8f, spaceBelow: 8f, lineColor: CommonColors.White)]
        public int anotherVariables_1;
        public int anotherVariables_2;
        public int anotherVariables_3;

        [Title("Title with specific line color", spaceAbove: 8f, spaceBelow: 8f, lineColor: CommonColors.Red)]
        public int anotherVariables_4;
        public int anotherVariables_5;
        public int anotherVariables_6;

        [Title("Title with specific heading color", spaceAbove: 8f, spaceBelow: 8f, headingColor: CommonColors.Yellow)]
        public int anotherVariables_7;
        public int anotherVariables_8;
        public int anotherVariables_9;

        [Title("Title with specific heading and line color", spaceAbove: 8f, spaceBelow: 8f, lineColor: CommonColors.Aqua, headingColor: CommonColors.Green)]
        public int anotherVariables_10;
        public int anotherVariables_11;
        public int anotherVariables_12;
    }
}