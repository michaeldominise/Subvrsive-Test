using UnityEngine;
namespace EnivStudios.EnivInspector
{
    public class Button : MonoBehaviour
    {
        [Button("SomeMethod", spaceAbove: 5f, spaceBelow: 0f)]
        [SerializeField] private string clickMe;

        [Button("AnotherMethod", labelFontSize: 15, buttonSize: 26f, spaceAbove: 5f, spaceBelow: 2f)]
        [SerializeField] private string clickMeToo;
        public void SomeMethod()
        {
            Debug.Log("Some Action Performed");
        }
        public void AnotherMethod()
        {
            Debug.Log("Another Action Performed");
        }
    }
}