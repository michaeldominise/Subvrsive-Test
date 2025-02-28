using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Subvrsive
{
    public class PlayerAttackController : MonoBehaviour
    {
        public enum State { None, Attacking, AttackDone, Cooldown }

        [SerializeField] CharacterData characterData;
        [SerializeField] PlayerMainBehaviour playerMainBehaviour;

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

        Coroutine atttackCoroutine;
        NavMeshAgent NavMeshAgent => playerMainBehaviour.NavMeshAgent;
        Transform Target { get => playerMainBehaviour.target; set => playerMainBehaviour.target = value; }


        public void Init(CharacterData characterData)
        {
            this.characterData = characterData;
            StartCoroutine(CheckEnemies());
        }

        IEnumerator CheckEnemies()
        {
            while(true)
            {
                if (currentState == State.AttackDone)
                    yield return StartCooldown();
                RefreshTarget();
                yield return null;
            }
        }

        void RefreshTarget()
        {
            if (Target == null)
            {
                var colliders = Physics.OverlapSphere(transform.position, characterData.attribute.attackRange, ~gameObject.layer);
                foreach (var collider in colliders)
                    if (transform != collider.transform)
                    {
                        StartAttack();
                        Target = collider.transform;
                    }
            }
            else if (currentState != State.Attacking)
            {
                if (Vector3.Distance(transform.position, Target.position) > characterData.attribute.attackRange + NavMeshAgent.radius)
                    Target = null;
            }
        }

        void StartAttack()
        {
            if(atttackCoroutine == null)
                atttackCoroutine = StartCoroutine(_StartAttack());
        }

        IEnumerator _StartAttack()
        {
            CurrentState = State.Attacking;

            yield return new WaitForSeconds(characterData.attribute.attackDelay);
            SpawnBullet();

            atttackCoroutine = null;
        }

        IEnumerator StartCooldown()
        {
            CurrentState = State.Cooldown;
            yield return new WaitForSeconds(Random.Range(characterData.attribute.attackCooldown.x, characterData.attribute.attackCooldown.y));
        }

        void SpawnBullet()
        {

        }
    }
}
