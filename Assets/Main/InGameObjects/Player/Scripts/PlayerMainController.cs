using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Subvrsive
{
    public class PlayerMainBehaviour : MonoBehaviour
    {
        public enum State { None, Moving, Attacking, Dead }

        [SerializeField] CharacterData characterData;
        [SerializeField] NavMeshAgent navMeshAgent;
        [SerializeField] Transform model;
        [SerializeField] PlayerMovementController playerMovementController;
        [SerializeField] PlayerAttackController playerAttackController;
        [SerializeField] PlayerRotationController playerRotationController;
        [SerializeField] PlayerHealthController playerHealthController;
        [SerializeField] PlayerAnimationController playerAnimationController;

        public PlayerMainBehaviour target;
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
        public PlayerRotationController PlayerRotationController => playerRotationController;
        public PlayerHealthController PlayerHealthController => playerHealthController;

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
            playerHealthController.OnStateUpdate += state =>
            {
                switch (state)
                {
                    case PlayerHealthController.State.Dead:
                        CurrentState = State.Dead;
                        StartCoroutine(Kill());
                        break;
                }
            };
        }

        public void Init(CharacterData characterData, int index)
        {
            if (!isRegisterListenerDone)
                RegisterListener();

            gameObject.SetActive(true);
            gameObject.name = $"{characterData.name}:({index})";
            this.characterData = characterData;
            playerMovementController.Init(this, index);
            playerAttackController.Init(this);
            playerRotationController.Init(this);
            playerHealthController.Init(this);
            playerAnimationController.Init(this);
        }

        IEnumerator Kill()
        {
            yield return new WaitForSeconds(2);
            gameObject.SetActive(false);
        }
    }
}
