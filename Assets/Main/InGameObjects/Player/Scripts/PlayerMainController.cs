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
        [SerializeField] Transform model;
        [SerializeField] PlayerMovementController playerMovementController;
        [SerializeField] PlayerAttackController playerAttackController;
        [SerializeField] PlayerRotationController playerRotationController;

        public Transform target;
        public bool isRegisterListenerDone;

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

        public CharacterData CharacterData => characterData;
        public NavMeshAgent NavMeshAgent => navMeshAgent;
        public Transform Model => model;
        public PlayerAttackController PlayerAttackController => playerAttackController;

        private void RegisterListener()
        {
            isRegisterListenerDone = true;
            playerMovementController.OnStateUpdate += state => CurrentState = state == PlayerMovementController.State.Moving ? State.Moving : currentState;
            playerAttackController.OnStateUpdate += state =>
                CurrentState = state switch
                {
                    PlayerAttackController.State.Attacking => State.Attacking,
                    PlayerAttackController.State.AttackDone => State.None,
                    _ => currentState,
                };
        }

        public void Init(CharacterData characterData, int index)
        {
            if (!isRegisterListenerDone)
                RegisterListener();

            this.characterData = characterData;
            playerMovementController.Init(this, index);
            playerAttackController.Init(this);
            playerRotationController.Init(this);
        }

        public void DoDamage(float damage)
        {
        }
    }
}
