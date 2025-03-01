using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Subvrsive
{
    public class BulletSpawner : MonoBehaviour
    {
        public static BulletSpawner Instance { get; private set; }
        public static event Action<BulletController> onBulletSpawned;

        [SerializeField] Transform spawnParent;
        [SerializeField] List<BulletController> bulletList;

        private void Awake() => Instance = this;

        public void Spawn(PlayerMainBehaviour playerMainBehaviour)
        {
            var bullet = bulletList.FirstOrDefault(x => x.BulletData == playerMainBehaviour.CharacterData.inGameObjects.bulletData && !x.gameObject.activeInHierarchy);
            if (!bullet)
            {
                bullet = Instantiate(playerMainBehaviour.CharacterData.inGameObjects.bulletData.inGameObjects.bulletPrefab, spawnParent);
                bulletList.Add(bullet);
            }

            bullet.Init(playerMainBehaviour);
            onBulletSpawned?.Invoke(bullet);
        }
    }
}
