using UnityEngine;
namespace EnivStudios.EnivInspector
{

    public class Tab : MonoBehaviour
    {
        [Tab("Tab 1", spaceAbove: 10f)]
        [HideInInspector][SerializeField] private string property1;

        [Tab("Tab 1")]
        [HideInInspector] public int property2;

        [Tab("Tab 2", spaceAbove: 10f)]
        [HideInInspector] public float property3;

        [Tab("Tab 2")]
        [HideInInspector] public bool property4;

        [Tab("Tab 3", spaceAbove: 10f)]
        [HideInInspector] public float property5;

        [Tab("Tab 3")]
        [HideInInspector] public bool property6;
    }
}