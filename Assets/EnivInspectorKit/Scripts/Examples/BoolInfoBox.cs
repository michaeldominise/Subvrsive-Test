using UnityEngine;

namespace EnivStudios.EnivInspector
{
    public class BoolInfoBox : MonoBehaviour
    {
        [SerializeField] private bool someCondition;

        [IfBool("someCondition", showProperty: true)][SerializeField] private int intVar;
        [IfBool("someCondition", showProperty: true)][SerializeField] private Vector2 vector2;
        [IfBool("someCondition", showProperty: true)][SerializeField] private bool isOk;

        [BoolInfoBox("Hi Everyone", "someCondition", true, spaceAbove: 2, spaceBelow: 2, MessageType.Info)][SerializeField] private bool isOkk;
    }
}