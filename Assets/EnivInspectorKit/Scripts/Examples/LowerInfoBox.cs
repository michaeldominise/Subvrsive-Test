using UnityEngine;
namespace EnivStudios.EnivInspector
{
    public class LowerInfoBox : MonoBehaviour
    {
        [LowerInfoBox("This variable calculates cat speed", MessageType.Info, spaceAbove: 2f, spaceBelow: 2f)]
        [SerializeField] private int catRunSpeed;

        [LowerInfoBox("Make sure dog speed doesn't increase too much!", MessageType.Warning, spaceAbove: 2f, spaceBelow: 2f)]
        [SerializeField] private int dogRunSpeed;

        [LowerInfoBox("Parrot don't run they fly!", MessageType.Error, spaceAbove: 2f, spaceBelow: 2f)]
        [SerializeField] private int parrotRunSpeed;
    }
}