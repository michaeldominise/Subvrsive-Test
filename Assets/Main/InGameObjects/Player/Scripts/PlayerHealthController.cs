using System;
using UnityEngine;

namespace Subvrsive
{
    public class PlayerHealthController : MonoBehaviour
    {
        public enum State { Alive, Dead }
        [SerializeField] int health;

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
        public event Action<int> OnHealthUpdate;

        PlayerMainBehaviour playerMainBehaviour;
        CharacterData CharacterData => playerMainBehaviour.CharacterData;


        public void Init(PlayerMainBehaviour playerMainBehaviour)
        {
            this.playerMainBehaviour = playerMainBehaviour;

            health = CharacterData.attribute.maxHealth;
        }

        public void DoDamage(int value) => AddHealth(-value);
        public void AddHealth(int value)
        {
            if (CurrentState == State.Dead)
                return;

            health = Mathf.Clamp(health + value, 0, CharacterData.attribute.maxHealth);
            OnHealthUpdate?.Invoke(health);
            CurrentState = health > 0 ? State.Alive : State.Dead;
        }
    }
}
