using UnityEngine;
namespace EnivStudios.EnivInspector
{

    public class Name : MonoBehaviour
    {
        [Name("Int Variable")]
        [SerializeField] private int var;
    }
}