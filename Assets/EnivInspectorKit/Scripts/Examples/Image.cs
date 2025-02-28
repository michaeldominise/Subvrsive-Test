using UnityEngine;
namespace EnivStudios.EnivInspector
{
    public class Image : MonoBehaviour
    {
        [Image(imagePath: "Assets/EnivInspectorKit/Images/Logo_1.png", imageHeight: 130f, spaceAbove: 5f, spaceBelow: 8f)]
        [SerializeField] private int someVariable;
        [SerializeField] private Vector3 vector3;

        [Image(imagePath: "Assets/EnivInspectorKit/Images/Logo_2.png", imageHeight: 90f, spaceAbove: 5f, spaceBelow: 5f)]
        [SerializeField] private string someText;
        [SerializeField] private bool isWorking;

        [Image(imagePath: "Assets/EnivInspectorKit/Images/Logo_3.png", imageHeight: 50f, spaceAbove: 5f, spaceBelow: 5f)]
        [SerializeField] private Transform transformObject;
        [SerializeField] private GameObject gameObj;
    }
}