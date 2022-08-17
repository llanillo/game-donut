using Managers;
using Player.Controllers.Others;
using Templates.Weapons.Long_Range;
using UnityEngine;

namespace Weapons.Bullets.Enemy
{
    public class EnemyBullet : Bullet
    {
        private PlayerHealth health;

        private void Start()
        {
            var gameController = GameObject.FindGameObjectWithTag("GameController");
            health = gameController.GetComponent<PlayerManager>().Health;
        }

        protected void OnEnable()
        {
            bulletRb.AddForce(BulletDirection * BulletSpeed);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (!other.CompareTag("Player")) return;
            health.ReduceHealth(Damage);
            gameObject.SetActive(false);
        }
    }
}