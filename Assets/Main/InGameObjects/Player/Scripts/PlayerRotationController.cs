using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Subvrsive
{
    public class PlayerRotationController : MonoBehaviour
    {
        [SerializeField] CharacterData characterData;
        [SerializeField] Transform model;
        [SerializeField] PlayerMainBehaviour playerMainBehaviour;

        Transform Target => playerMainBehaviour.target;
        NavMeshAgent NavMeshAgent => playerMainBehaviour.NavMeshAgent;

        public void Init(CharacterData characterData) => this.characterData = characterData;

        private void Update()
        {
            RefreshDirection();
        }

        void RefreshDirection()
        {
            Vector3 relativePos = (Target ? Target.position : NavMeshAgent.destination) - model.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            model.rotation = Quaternion.Lerp(model.rotation, rotation, Time.deltaTime * characterData.attribute.rotateSpeed);
        }
    }
}
