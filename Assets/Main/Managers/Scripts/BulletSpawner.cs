using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Subvrsive
{
    public class BulletSpawner : Spawner<BulletController>
    {
        public static BulletSpawner Instance { get; private set; }

        private void Awake() => Instance = this;

        public void Spawn(PlayerMainController playerMainController)
            => Spawn(playerMainController.CharacterData.inGameObjects.weaponData.inGameObjects.bulletData.inGameObjects.bulletPrefab,
                x => x.BulletData == playerMainController.CharacterData.inGameObjects.weaponData.inGameObjects.bulletData,
                init: item => item.Init(playerMainController));
    }
}
