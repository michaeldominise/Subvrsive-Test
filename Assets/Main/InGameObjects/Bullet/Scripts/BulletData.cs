using System;
using UnityEngine;


namespace Subvrsive
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "GameData/BulletData")]
    public class BulletData : ScriptableObject
    {
        [Serializable]
        public class Attribute
        {
            public Vector2 force = Vector2.one;
            public float lifeSpan = 1f;
            public float explosionRadius = 1f;
        }

        [Serializable]
        public class InGameObjects
        {
            public Sprite bulletSprite;
            public BulletController bulletPrefab;
        }

        public Attribute attribute;
        public InGameObjects inGameObjects;
    }
}
