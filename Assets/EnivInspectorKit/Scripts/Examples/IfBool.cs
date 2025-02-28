using UnityEngine;
namespace EnivStudios.EnivInspector
{
    public class IfBool : MonoBehaviour
    {
        [SerializeField] private bool someCondition;

        [IfBool("someCondition", showProperty: true)][SerializeField] private int intVar;
        [IfBool("someCondition", showProperty: true)][SerializeField] private Vector2 vector2;
        [IfBool("someCondition", showProperty: true)][SerializeField] private bool isOk;

    }
}