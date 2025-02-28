
using UnityEngine;
namespace EnivStudios.EnivInspector
{

    public class FoldoutGroup : MonoBehaviour
    {

        [FoldoutGroup("Cat Properties", spaceAbove: 10f, spaceBelow: 0)]
        [HideInInspector] public string catName;

        [FoldoutGroup("Cat Properties")]
        [HideInInspector] public Color colorPicker;

        [FoldoutGroup("Dog Properties", spaceAbove: 0, spaceBelow: 10f)]
        [HideInInspector] public string dogName;

        [FoldoutGroup("Dog Properties")]
        [HideInInspector] public KeyCode selectKey;

    }
}