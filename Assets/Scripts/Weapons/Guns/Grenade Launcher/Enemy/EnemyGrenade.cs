using Managers;
using Player.Controllers.Others;
using Player.Controllers.Player_movement;
using Templates.Weapons.Long_Range;
using UnityEngine;

namespace Weapons.Guns.Grenade_Launcher.Enemy
{
    public class EnemyGrenade : Grenade
    {
        private PlayerHealth health;

        private void Start()
        {
            var gameController = GameObject.FindGameObjectWithTag("GameController");
            health = gameController.GetComponent<PlayerManager>().Health;
        }

        // Explodes immediately if players touch the grenade
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
                Physics.IgnoreCollision(collision.transform.GetComponent<Collider>(), GetComponent<Collider>());

            if (collision.gameObject.CompareTag("Player")) StartCoroutine(Explosion(0));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var position = transform.position;
            Gizmos.DrawWireSphere(position, ExplosionRadius);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(position, ExplosionRadius / 1.3f);
        }

        protected override void HandleCollisions()
        {
            base.HandleCollisions();

            foreach (var colliderObj in colliders)
                if (colliderObj.CompareTag("Player"))
                    AddKnockBack(colliderObj);
        }

        private void AddKnockBack(Collider colliderObj)
        {
            var playerPosition = colliderObj.transform.position;
            var transform1 = transform;
            var position = transform1.position;
            var knockBackDirection = playerPosition - position;
            knockBackDirection.y = 0;

            var distanceToPlayer = Vector3.Distance(position, playerPosition);

            var player = colliderObj.GetComponent<PlayerKnockBack>();

            if (distanceToPlayer > ExplosionRadius / 1.3f)
            {
                health.ReduceHealth(Damage);
                player.AddKnockBack(knockBackDirection.normalized, Force, Length);
            }
            else
            {
                health.ReduceHealth(Damage * 2);
                player.AddKnockBack(knockBackDirection.normalized, Force * 2, Length * 1.75f);
            }
        }
    }
}