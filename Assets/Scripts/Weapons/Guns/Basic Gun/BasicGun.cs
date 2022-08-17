using Templates.Weapons.Gun;
using Templates.Weapons.Long_Range;
using UnityEngine;

namespace Weapons.Guns.Basic_Gun
{
    public class BasicGun : Gun
    {
        public override void Attack(Vector3 attackDirection)
        {
            attackDirection.y = 0;
            base.Attack(attackDirection);
        }

        protected override void CreateBullet()
        {
            base.CreateBullet();

            var bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Damage = data.damage;
            bulletScript.BulletSpeed = data.bulletSpeed;
            bulletScript.BulletDirection = shootDirection;

            bullet.SetActive(true);
        }
    }
}