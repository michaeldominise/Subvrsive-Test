using UnityEngine;
namespace EnivStudios.EnivInspector
{
    public class Vector2Slider : MonoBehaviour
    {
        [Vector2Slider(xValue: 100f, yValue: 400f)]
        [SerializeField] private Vector2 vector2Field;
    }
}