using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Subvrsive
{
    public class PlayerSpawner : MonoBehaviour
    {
        public static event Action<PlayerBehaviour> onPlayerSpawned;

        [SerializeField] int spawnRange = 10;
        [SerializeField] int spawnCount = 10;
        [SerializeField] Transform spawnParent;
        [SerializeField] List<CharacterData> characterList;

        public void Start()
        {
            for (var x = 0; x < spawnCount; x++)
                SpawnPlayer(characterList[UnityEngine.Random.Range(0, characterList.Count)]);
        }

        public PlayerBehaviour SpawnPlayer(CharacterData characterData)
        {
            RandomPoint(transform.position, spawnRange, out Vector3 spanwPoint);
            var playerBehaviour = Instantiate(characterData.inGameObjects.playerPrefab, spanwPoint, Quaternion.identity);
            playerBehaviour.Init(characterData);

            return playerBehaviour;
        }

        bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {
            for (int i = 0; i < 30; i++)
            {
                Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
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
