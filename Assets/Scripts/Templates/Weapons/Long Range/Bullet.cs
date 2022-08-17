using UnityEngine;

namespace Templates.Weapons.Long_Range
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        protected Rigidbody bulletRb;
        public float Damage { get; set; }
        public float BulletSpeed { get; set; }
        public Vector3 BulletDirection { get; set; }

        private void Awake()
        {
            bulletRb = GetComponent<Rigidbody>();
        }

        private void OnDisable()
        {
            bulletRb.velocity = Vector3.zero;
            transform.forward = Vector3.one;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Environment"))
                gameObject.SetActive(false);
        }
    }
}