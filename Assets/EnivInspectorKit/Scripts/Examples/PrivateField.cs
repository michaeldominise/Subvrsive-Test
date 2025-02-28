using UnityEngine;

namespace EnivStudios.EnivInspector
{
	public class PrivateField : MonoBehaviour
	{
		
		[PrivateField] [SerializeField] private int x;
	}
}