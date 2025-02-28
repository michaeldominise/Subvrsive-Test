using UnityEngine;
using EnivStudios.EnivInspector;


namespace Subvrsive
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameData/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public class Attribute
        {
            public float health = 100f;
            public float movementSpeed = 1f;
            public float rotateSpeed = 1f;
            public float damage = 10f;

            [Vector2Slider(0, 1)]
            public float aggressiveValue = 0.5f;
        }

        public class InGameObjects
        {
            public Sprite bulletSprite;
            public GameObject bulletPrefab;
            public GameObject characterPrefab;
        }
    }
}
