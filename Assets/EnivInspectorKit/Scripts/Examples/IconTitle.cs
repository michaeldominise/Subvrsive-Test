using UnityEngine;
namespace EnivStudios.EnivInspector
{

    public class IconTitle : MonoBehaviour
    {
        [IconTitle("Assets/EnivInspectorKit/Images/monitor-check.png", spaceAbove: 0, spaceBelow: 5)]
        [SerializeField] private string displaySettings; //Icon Title Name
        [SerializeField] private int someVar_1;
        [SerializeField] private Vector2 screenResolution;

        [IconTitle("Assets/EnivInspectorKit/Images/headphones.png", spaceAbove: 5, spaceBelow: 5)]
        [SerializeField] private string soundSettings; //Icon Title Name
        [SerializeField] private int someVar_2;
        [SerializeField][Range(1, 10)] private int soundVolume;

        [IconTitle("Assets/EnivInspectorKit/Images/file-type.png", spaceAbove: 5, spaceBelow: 0)]
        [SerializeField] private string uISettings; //Icon Title Name
        [SerializeField] private Image logo;
        [SerializeField] private int someVar_3;
    }
}