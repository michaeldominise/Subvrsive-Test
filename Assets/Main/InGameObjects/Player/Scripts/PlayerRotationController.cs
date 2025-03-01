using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Subvrsive
{
    public class PlayerRotationController : MonoBehaviour
    {
        PlayerMainBehaviour playerMainBehaviour;
        CharacterData CharacterData => playerMainBehaviour.CharacterData;
        Transform Target => playerMainBehaviour.target;
        NavMeshAgent NavMeshAgent => playerMainBehaviour.NavMeshAgent;
        Transform Model => playerMainBehaviour.Model;

        public void Init(PlayerMainBehaviour playerMainBehaviour) => this.playerMainBehaviour = playerMainBehaviour;

        private void Update()
        {
            RefreshDirection();
        }

        void RefreshDirection()
        {
            Vector3 relativePos = (Target ? Target.position : NavMeshAgent.destination) - Model.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            Model.rotation = Quaternion.RotateTowards(Model.rotation, rotation, Time.deltaTime * CharacterData.attribute.rotateSpeed);
        }
    }
}
