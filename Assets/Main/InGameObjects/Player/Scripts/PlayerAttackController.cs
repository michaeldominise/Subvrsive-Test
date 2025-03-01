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

        [SerializeField] Transform spawnPoint;
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

        public Transform SpawnPoint => spawnPoint;

        PlayerMainBehaviour playerMainBehaviour;
        Coroutine atttackCoroutine;
        CharacterData CharacterData => playerMainBehaviour.CharacterData;
        NavMeshAgent NavMeshAgent => playerMainBehaviour.NavMeshAgent;
        PlayerMainBehaviour Target { get => playerMainBehaviour.target; set => playerMainBehaviour.target = value; }


        public void Init(PlayerMainBehaviour playerMainBehaviour)
        {
            this.playerMainBehaviour = playerMainBehaviour;
            StartCoroutine(CheckEnemies());
        }

        private void Start() => playerMainBehaviour.OnStateUpdate += state =>
            {
                switch (state)
                {
                    case PlayerMainBehaviour.State.Dead:
                        StopAllCoroutines();
                        currentState = State.None;
                        break;
                    default:
                        break;
                }
            };

        IEnumerator CheckEnemies()
        {
            yield return new WaitForSeconds(Random.value * 3);
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
                var colliders = Physics.OverlapSphere(transform.position, CharacterData.attribute.attackRange, 1 << gameObject.layer);
                foreach (var collider in colliders)
                    if (transform != collider.transform)
                    {
                        var hit = collider.GetComponent<PlayerMainBehaviour>();
                        if (hit.CurrentState == PlayerMainBehaviour.State.Dead)
                            continue;

                        Target = hit;
                        StartAttack();
                        break;
                    }
            }
            else if (currentState == State.None)
            {
                if (Target.CurrentState == PlayerMainBehaviour.State.Dead || Vector3.Distance(transform.position, Target.transform.position) > CharacterData.attribute.attackRange + NavMeshAgent.radius)
                    Target = null;
                else
                    StartAttack();
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

            yield return null;
            yield return new WaitUntil(() => playerMainBehaviour.PlayerRotationController.CurrentState == PlayerRotationController.State.None);
            yield return new WaitForSeconds(CharacterData.attribute.attackDelay);

            BulletSpawner.Instance.Spawn(playerMainBehaviour);

            CurrentState = State.AttackDone;
            atttackCoroutine = null;
        }

        IEnumerator StartCooldown()
        {
            CurrentState = State.Cooldown;
            yield return new WaitForSeconds(Random.Range(CharacterData.attribute.attackCooldown.x, CharacterData.attribute.attackCooldown.y));
            CurrentState = State.None;
        }
    }
}
