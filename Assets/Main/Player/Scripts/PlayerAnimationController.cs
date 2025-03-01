using UnityEngine;

namespace Subvrsive
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] Animator animator;

        PlayerMainController playerMainController;

        public void Init(PlayerMainController playerMainController)
        {
            this.playerMainController = playerMainController;
            animator.SetBool("alive", true);
        }

        private void Start() => playerMainController.OnStateUpdate += state =>
        {
            switch (state)
            {
                case PlayerMainController.State.Dead:
                    animator.SetBool("alive", false);
                    break;
            }
        };
    }
}
