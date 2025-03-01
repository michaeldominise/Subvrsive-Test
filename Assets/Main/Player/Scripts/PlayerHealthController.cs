using System;
using UnityEngine;

namespace Subvrsive
{
    public class PlayerHealthController : MonoBehaviour
    {
        public enum State { Alive, Dead }
        [SerializeField] int currentHealth;

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

        public int CurrentHealth => currentHealth;
        public int MaxHealth => CharacterData.attribute.maxHealth;
        public float HealthProgress => (float)CurrentHealth / CharacterData.attribute.maxHealth;

        public event Action<State> OnStateUpdate;
        public event Action<int> OnHealthUpdate;

        PlayerMainController playerMainController;
        CharacterData CharacterData => playerMainController.CharacterData;


        public void Init(PlayerMainController playerMainController)
        {
            currentState = State.Alive;
            this.playerMainController = playerMainController;

            currentHealth = MaxHealth;
        }

        public void DoDamage(int value) => AddHealth(-value);
        public void AddHealth(int value)
        {
            if (CurrentState == State.Dead)
                return;

            currentHealth = Mathf.Clamp(currentHealth + value, 0, CharacterData.attribute.maxHealth);
            OnHealthUpdate?.Invoke(currentHealth);
            CurrentState = currentHealth > 0 ? State.Alive : State.Dead;
        }
    }
}
