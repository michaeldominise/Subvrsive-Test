using UnityEngine;
using UnityEngine.AI;

namespace Subvrsive
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] NavMeshAgent navMeshAgent;
        [SerializeField] float randomPathRange = 10.0f;
        [SerializeField] CharacterData characterData;

        internal void Init(CharacterData characterData)
        {
            this.characterData = characterData;
            navMeshAgent.speed = characterData.attribute.movementSpeed;
        }

        private void Start()
        {
            navMeshAgent.updateRotation = false;
        }

        void Update()
        {
            if (navMeshAgent.remainingDistance == 0 && GetRandomPoint(transform.position, randomPathRange, out Vector3 point))
            {
                navMeshAgent.destination = point;
            }
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
