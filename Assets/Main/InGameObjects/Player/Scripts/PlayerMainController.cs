using System;
using UnityEngine;
using UnityEngine.AI;

namespace Subvrsive
{
    public class PlayerMainBehaviour : MonoBehaviour
    {
        public enum State { None, Moving, Attacking, Damaged, Dead }

        [SerializeField] CharacterData characterData;
        [SerializeField] NavMeshAgent navMeshAgent;
        [SerializeField] PlayerMovementController playerMovementController;
        [SerializeField] PlayerAttackController playerAttackController;
        [SerializeField] PlayerRotationController playerRotationController;

        public Transform target;

        [SerializeField] State currentState;
        public State CurrentState
        {
            get => currentState;
            set
            {
                if (currentState == value)
                    return;
                OnStateUpdate?.Invoke(currentState);
            }
        }

        public event Action<State> OnStateUpdate;

        public NavMeshAgent NavMeshAgent => navMeshAgent;
        public PlayerAttackController PlayerAttackController => playerAttackController;

        private void Start()
        {
            playerMovementController.OnStateUpdate += state => currentState = state == PlayerMovementController.State.Moving ? State.Moving : currentState;
            playerAttackController.OnStateUpdate += state => currentState = state == PlayerAttackController.State.Attacking ? State.Attacking : currentState;
        }

        public void Init(CharacterData characterData, int index)
        {
            this.characterData = characterData;
            playerMovementController.Init(characterData, index);
            playerAttackController.Init(characterData);
            playerRotationController.Init(characterData);
        }
    }
}
