using UnityEngine;

namespace Subvrsive
{
    public class CharacterWorldUISpawner : Spawner<CharacterWorldUI>
    {
        public static CharacterWorldUISpawner Instance { get; private set; }

        [SerializeField] CharacterWorldUI prefab;
        [SerializeField] Camera worldCamera;

        private void Awake() => Instance = this;
        private void Start() => PlayerSpawner.Instance.OnSpawned += Spawn;
        public void Spawn(PlayerMainController playerMainController) => Spawn(prefab, init: item => item.Init(playerMainController, worldCamera));
    }
}
