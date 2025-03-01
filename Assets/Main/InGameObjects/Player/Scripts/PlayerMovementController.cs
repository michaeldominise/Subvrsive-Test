using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Subvrsive
{
    public class PlayerMovementController : MonoBehaviour
    {
        public enum State { Idle, Moving }

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
        NavMeshAgent NavMeshAgent => playerMainBehaviour.NavMeshAgent;

        Coroutine moveCoroutine;

        public void Init(PlayerMainBehaviour playerMainBehaviour, int index)
        {
                this.playerMainBehaviour = playerMainBehaviour;
                NavMeshAgent.avoidancePriority = index;
            NavMeshAgent.updateRotation = false;
            StartMoving();
        }

        private void Start() => playerMainBehaviour.OnStateUpdate += state =>
            {
                switch (state)
                {
                    case PlayerMainBehaviour.State.Moving:
                        break;
                    case PlayerMainBehaviour.State.Attacking:
                    case PlayerMainBehaviour.State.Dead:
                        StopMoving();
                        break;
                    default:
                        StartMoving();
                        break;
                }
            };

        public void StartMoving()
        {
            if(moveCoroutine == null)
                moveCoroutine = StartCoroutine(_StartMoving());
        }


        IEnumerator _StartMoving()
        {
            CurrentState = State.Moving;

            NavMeshAgent.isStopped = false;
            while (true)
            {
                yield return null;
                RefreshDestination();
            }
        }

        public void StopMoving()
        {
            NavMeshAgent.isStopped = true;
            StopCoroutine(moveCoroutine);

            moveCoroutine = null;
            CurrentState = State.Idle;
        }

        void RefreshDestination()
        {
            if (NavMeshAgent.remainingDistance > 0 || !GetRandomPoint(transform.position, CharacterData.attribute.randomPathRange, out Vector3 point))
                return;
            NavMeshAgent.destination = point;
        }

        bool GetRandomPoint(Vector3 center, float range, out Vector3 result)
        {
            for (int i = 0; i < 30; i++)
            {
                var randomPoint = center + Random.insideUnitSphere * range;
                if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
                {
                    result = hit.position;
                    return true;
                }
            }
            result = Vector3.zero;
            return false;
        }
    }
}
