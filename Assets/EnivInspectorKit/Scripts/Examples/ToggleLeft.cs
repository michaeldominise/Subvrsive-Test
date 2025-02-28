using UnityEngine;
namespace EnivStudios.EnivInspector
{
    public class ToggleLeft : MonoBehaviour
    {
        [ToggleLeft]
        [SerializeField] private bool enableFeature;

        [IfBool("enableFeature", showProperty: true)][SerializeField] private int anotherVar;
        [IfBool("enableFeature", showProperty: true)][SerializeField] private Vector2 anotherVector2;
        [IfBool("enableFeature", showProperty: true)][SerializeField] private bool anotherIsOk;
    }
}