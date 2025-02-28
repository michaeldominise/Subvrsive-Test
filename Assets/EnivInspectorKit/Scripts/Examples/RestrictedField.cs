using UnityEngine;
namespace EnivStudios.EnivInspector
{
	public class RestrictedField : MonoBehaviour
	{
		[SerializeField] private bool someCondition;

		[RestrictedField("someCondition")][SerializeField] private string fieldName;
		[RestrictedField("someCondition")][SerializeField] private int fieldValue;
		[RestrictedField("someCondition")][SerializeField] private Quaternion fieldRotation;

	}
}