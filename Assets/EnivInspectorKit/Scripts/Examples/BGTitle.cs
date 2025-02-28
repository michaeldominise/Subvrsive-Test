using UnityEngine;

namespace EnivStudios.EnivInspector
{
    public class BGTitle : MonoBehaviour
    {
        [BGTitle("Title With InfoBox Color And No Spacing", colorScheme: ColorScheme.InfoBox, centerTitle: false, spaceAbove: 0f, spaceBelow: 0f, boxHeight: 2.2f)]
        public int someVar_1;
        public int someVar_2;
        public int someVar_3;

        [BGTitle("Title With InfoBox Color And Spacing", colorScheme: ColorScheme.InfoBox, centerTitle: false, spaceAbove: 15f, spaceBelow: 15f, boxHeight: 2.2f)]
        public int someVar_4;
        public int someVar_5;
        public int someVar_6;

        [BGTitle("Title With TextField Color And Spacing", colorScheme: ColorScheme.TextField, centerTitle: false, spaceAbove: 15f, spaceBelow: 15f, boxHeight: 2.2f)]
        public int someVar_7;
        public int someVar_8;
        public int someVar_9;

        [BGTitle("Center Title With TextField Color And Spacing", colorScheme: ColorScheme.TextField, centerTitle: true, spaceAbove: 15f, spaceBelow: 15f, boxHeight: 2.2f)]
        public int someVar_10;
        public int someVar_11;
        public int someVar_12;

        [BGTitle("Description With TextField Color And Spacing.\nYou can also adjust the height of the box.", colorScheme: ColorScheme.TextField, centerTitle: true, spaceAbove: 15f, spaceBelow: 15f, boxHeight: 4.4f)]
        public int someVar_13;
        public int someVar_14;
        public int someVar_15;

    }
}
