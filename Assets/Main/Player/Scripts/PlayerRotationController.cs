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

        PlayerMainController playerMainController;
        CharacterData CharacterData => playerMainController.CharacterData;
        PlayerMainController Target => playerMainController.target;
        NavMeshAgent NavMeshAgent => playerMainController.NavMeshAgent;
        Transform Model => playerMainController.Model;

        public void Init(PlayerMainController playerMainController)
        {
            currentState = State.None;
            this.playerMainController = playerMainController;
        }

        private void Update()
        {
            if (playerMainController.CurrentState == PlayerMainController.State.Dead)
                return;

            RefreshDirection();
        }

        void RefreshDirection()
        {
            Vector3 relativePos = (Target && Target.CurrentState != PlayerMainController.State.Dead ? Target.transform.position : NavMeshAgent.destination) - Model.position;
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
