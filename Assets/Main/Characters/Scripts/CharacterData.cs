using UnityEngine;
using EnivStudios.EnivInspector;


namespace Subvrsive
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameData/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public class Attribute
        {
            public float health = 1f;
            public float speed = 1f;
            public float damage = 1f;
        }

        public class InGameObjects
        {
            public Sprite bulletSprite;
            public GameObject bulletPrefab;
            public GameObject characterPrefab;
        }
    }
}
