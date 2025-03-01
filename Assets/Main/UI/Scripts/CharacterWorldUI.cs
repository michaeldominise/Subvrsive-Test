using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Subvrsive
{
    public class CharacterWorldUI : MonoBehaviour
    {
        [SerializeField] PlayerMainController playerMainController;
        [SerializeField] Slider healthSlider;
        [SerializeField] Gradient healthColor;
        [SerializeField] TextMeshProUGUI playerName;
        [SerializeField] float updateDuration = 1;
        [SerializeField] Camera worldCamera;

        RectTransform RectParent => transform.parent as RectTransform;
        PlayerHealthController PlayerHealthController => playerMainController.PlayerHealthController;
        Coroutine updateHealthCoroutine;
        

        public void Init(PlayerMainController playerMainController, Camera worldCamera)
        {
            gameObject.SetActive(true);
            this.worldCamera = worldCamera;

            if (this.playerMainController)
                this.playerMainController.PlayerHealthController.OnHealthUpdate -= PlayerHealthController_OnHealthUpdate;

            this.playerMainController = playerMainController;
            this.playerMainController.PlayerHealthController.OnHealthUpdate += PlayerHealthController_OnHealthUpdate;

            playerName.text = playerMainController.gameObject.name;
            healthSlider.value = 0;
            UpdateHealth();
        }

        private void PlayerHealthController_OnHealthUpdate(int value) => UpdateHealth();

        void UpdateHealth()
        {
            if (updateHealthCoroutine != null)
                return;
            updateHealthCoroutine = StartCoroutine(_UpdateHealth());
        }

        IEnumerator _UpdateHealth()
        {
            var startTime = Time.time;
            var startValue = healthSlider.value;

            while (startTime + updateDuration > Time.time)
            {
                healthSlider.value = Mathf.Lerp(startValue, PlayerHealthController.HealthProgress, (Time.time - startTime) / updateDuration);
                healthSlider.image.CrossFadeColor(healthColor.Evaluate(healthSlider.value), 0, true, false);
                yield return null;
            }
            healthSlider.value = playerMainController.PlayerHealthController.HealthProgress;
            healthSlider.image.CrossFadeColor(healthColor.Evaluate(healthSlider.value), 0, true, false);
            if (healthSlider.value == 0)
                gameObject.SetActive(false);
            updateHealthCoroutine = null;
        }

        private void LateUpdate()
        {
            var viewportPoint = worldCamera.WorldToViewportPoint(playerMainController.WorldUIPoint.position);
            var halfScreenSize = new Vector3(RectParent.rect.width, RectParent.rect.height) * 0.5f;
            transform.localPosition = new Vector3(Mathf.Lerp(-halfScreenSize.x, halfScreenSize.x, viewportPoint.x), Mathf.Lerp(-halfScreenSize.y, halfScreenSize.y, viewportPoint.y));
        }
    }
}
