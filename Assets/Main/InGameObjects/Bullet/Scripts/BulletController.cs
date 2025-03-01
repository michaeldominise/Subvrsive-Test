using System;
using System.Collections;
using UnityEngine;

namespace Subvrsive
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] PlayerMainBehaviour source;
        [SerializeField] LayerMask playerLayer;

        public BulletData BulletData => source.CharacterData.inGameObjects.bulletData;

        BulletData.Attribute Attribute => BulletData.attribute;
        Transform SpawnPoint => source.PlayerAttackController.SpawnPoint;
        Vector3 bulletForwardForce => SpawnPoint.TransformPoint(0, Attribute.force.y, Attribute.force.x) - SpawnPoint.position;

        public void Init(PlayerMainBehaviour playerMainBehaviour)
        {
            source = playerMainBehaviour;

            gameObject.SetActive(true);
            transform.SetPositionAndRotation(SpawnPoint.position, SpawnPoint.rotation);
            _rigidbody.AddForce(bulletForwardForce, ForceMode.Impulse);
            StartCoroutine(AutoKill());
        }

        private void OnCollisionEnter(Collision collision) => OnHit(collision.transform);
        private void OnTriggerEnter(Collider collider) => OnHit(collider.transform);

        void OnHit(Transform hitTransform)
        {
            if (transform == hitTransform.transform || source.transform == hitTransform.transform)
                return;

            var hitList = Physics.OverlapSphere(transform.position, Attribute.explosionRadius, playerLayer);
            foreach (var hit in hitList)
                if (1 << hit.gameObject.layer == playerLayer)
                    hit.GetComponent<PlayerMainBehaviour>().DoDamage(source.CharacterData.attribute.damage);

            Die();
        }

        public IEnumerator AutoKill()
        {
            yield return new WaitForSeconds(Attribute.lifeSpan);
            Die();
        }

        void Die()
        {
            _rigidbody.angularVelocity = _rigidbody.linearVelocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
