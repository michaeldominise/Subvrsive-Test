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

        PlayerMainController playerMainController;
        Coroutine atttackCoroutine;
        CharacterData CharacterData => playerMainController.CharacterData;
        NavMeshAgent NavMeshAgent => playerMainController.NavMeshAgent;
        PlayerMainController Target { get => playerMainController.target; set => playerMainController.target = value; }


        public void Init(PlayerMainController playerMainController)
        {
            currentState = State.None;
            this.playerMainController = playerMainController;
            StartCoroutine(CheckEnemies());
        }

        private void Start() => playerMainController.OnStateUpdate += state =>
            {
                switch (state)
                {
                    case PlayerMainController.State.Dead:
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
                if (playerMainController.CurrentState == PlayerMainController.State.Dead)
                    break;

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
                var colliders = Physics.OverlapSphere(transform.position, CharacterData.inGameObjects.weaponData.attribute.attackRange, 1 << gameObject.layer);
                foreach (var collider in colliders)
                    if (transform != collider.transform)
                    {
                        var hit = collider.GetComponent<PlayerMainController>();
                        if (hit.CurrentState == PlayerMainController.State.Dead)
                            continue;

                        Target = hit;
                        StartAttack();
                        break;
                    }
            }
            else if (currentState == State.None)
            {
                if (Target.CurrentState == PlayerMainController.State.Dead || Vector3.Distance(transform.position, Target.transform.position) > CharacterData.inGameObjects.weaponData.attribute.attackRange + NavMeshAgent.radius)
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
            yield return new WaitUntil(() => playerMainController.PlayerRotationController.CurrentState == PlayerRotationController.State.None);
            yield return new WaitForSeconds(CharacterData.inGameObjects.weaponData.attribute.attackDelay);

            BulletSpawner.Instance.Spawn(playerMainController);

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
