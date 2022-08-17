using Enemy.Controllers.All;
using Templates.Weapons.Long_Range;
using UnityEngine;

namespace Weapons.Bullets.Player
{
    public class PlayerBullet : Bullet
    {
        protected void OnEnable()
        {
            bulletRb.AddForce(BulletDirection * BulletSpeed);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if (!other.CompareTag("Enemy")) return;
            
            other.GetComponent<EnemyHealth>().ReduceHealth(Damage);
            gameObject.SetActive(false);
        }
    }
}