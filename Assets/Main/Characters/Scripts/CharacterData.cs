using UnityEngine;


namespace Subvrsive
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "GameData/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [System.Serializable]
        public class Attribute
        {
            public float health = 100f;
            public float movementSpeed = 1f;
            public float randomPathRange = 5.0f;
            public float rotateSpeed = 1f;
            public float damage = 10f;
            public float attackDelay = 0.5f;
            public Vector2 attackCooldown = new Vector2(0.5f, 3);
            public float attackRange = 2f;

            [Range(0, 1)]
            public float aggressiveValue = 0.5f;
        }

        [System.Serializable]
        public class InGameObjects
        {
            public BulletData bulletData;
            public PlayerMainBehaviour playerPrefab;
        }

        public Attribute attribute;
        public InGameObjects inGameObjects;
    }
}
