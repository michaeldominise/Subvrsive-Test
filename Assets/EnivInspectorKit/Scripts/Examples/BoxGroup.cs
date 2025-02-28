using UnityEngine;
namespace EnivStudios.EnivInspector
{
    public class BoxGroup : MonoBehaviour
    {
        [BoxGroup("Group 1", spaceAbove: 10f, spaceBelow: 2f)][HideInInspector] public int x1;
        [BoxGroup("Group 1")][HideInInspector] public string y1;
        [BoxGroup("Group 1")][HideInInspector] public bool z1;

        [BoxGroup("Group 2", spaceAbove: 0f, spaceBelow: 10f)][HideInInspector] public float x2;
        [BoxGroup("Group 2")][HideInInspector] public Vector2 y2;
        [BoxGroup("Group 2")][HideInInspector] public Transform z2;
    }
}