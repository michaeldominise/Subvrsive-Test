using UnityEngine;


namespace Subvrsive
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameData/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [System.Serializable]
        public class Attribute
        {
            public float health = 100f;
            public float movementSpeed = 1f;
            public float rotateSpeed = 1f;
            public float damage = 10f;

            [Range(0, 1)]
            public float aggressiveValue = 0.5f;
        }

        [System.Serializable]
        public class InGameObjects
        {
            public Sprite bulletSprite;
            public GameObject bulletPrefab;
            public PlayerBehaviour playerPrefab;
        }

        public Attribute attribute;
        public InGameObjects inGameObjects;
    }
}
