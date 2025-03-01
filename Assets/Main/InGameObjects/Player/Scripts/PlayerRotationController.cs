using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Subvrsive
{
    public class PlayerRotationController : MonoBehaviour
    {
        public enum State { None, Rotating }

        [SerializeField] State currentState;
        public State CurrentState
        {
            get => currentState;
            set
            {
                if (currentState == value)
                    return;
                currentState = value;
                OnStateUpdate?.Invoke(currentState);
            }
        }

        public event Action<State> OnStateUpdate;

        PlayerMainBehaviour playerMainBehaviour;
        CharacterData CharacterData => playerMainBehaviour.CharacterData;
        PlayerMainBehaviour Target => playerMainBehaviour.target;
        NavMeshAgent NavMeshAgent => playerMainBehaviour.NavMeshAgent;
        Transform Model => playerMainBehaviour.Model;

        public void Init(PlayerMainBehaviour playerMainBehaviour) => this.playerMainBehaviour = playerMainBehaviour;

        private void Update()
        {
            if (playerMainBehaviour.CurrentState == PlayerMainBehaviour.State.Dead)
                return;

            RefreshDirection();
        }

        void RefreshDirection()
        {
            Vector3 relativePos = (Target && Target.CurrentState != PlayerMainBehaviour.State.Dead ? Target.transform.position : NavMeshAgent.destination) - Model.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            if (Model.rotation != rotation)
            {
                CurrentState = State.Rotating;
                Model.rotation = Quaternion.RotateTowards(Model.rotation, rotation, Time.deltaTime * CharacterData.attribute.rotateSpeed);
            }
            else
                CurrentState = State.None;
        }
    }
}
