using UnityEngine;
namespace EnivStudios.EnivInspector
{
    public class UpperInfoBox : MonoBehaviour
    {
        [UpperInfoBox("This variable calculates cat speed", MessageType.Info, spaceAbove: 2f, spaceBelow: 2f)]
        [SerializeField] private int catRunSpeed;

        [UpperInfoBox("Make sure dog speed doesn't increase too much!", MessageType.Warning, spaceAbove: 2f, spaceBelow: 2f)]
        [SerializeField] private int dogRunSpeed;

        [UpperInfoBox("Parrot don't run they fly!", MessageType.Error, spaceAbove: 2f, spaceBelow: 2f)]
        [SerializeField] private int parrotRunSpeed;
    }
}