using UnityEngine;

namespace Subvrsive
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] Animator animator;

        PlayerMainBehaviour playerMainBehaviour;

        public void Init(PlayerMainBehaviour playerMainBehaviour)
        {
            this.playerMainBehaviour = playerMainBehaviour;
            animator.SetBool("alive", true);
        }

        private void Start() => playerMainBehaviour.OnStateUpdate += state =>
        {
            switch (state)
            {
                case PlayerMainBehaviour.State.Dead:
                    animator.SetBool("alive", false);
                    break;
            }
        };
    }
}
