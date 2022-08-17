using System.Collections;
using Templates.Weapons.Base;
using UnityEngine;

namespace Templates.Weapons.Gun
{
    public abstract class Gun : Weapon
    {
        public Transform bulletSpawn;
        protected GameObject bullet;

        private bool isReloading;

        protected Vector3 shootDirection;

        private void Awake()
        {
            data.currentAmmo = data.maxAmmo;
        }

        private void OnEnable()
        {
            isReloading = false;
        }

        public override void Attack(Vector3 attackDirection)
        {
            shootDirection = attackDirection;

            if (data.currentAmmo == 0)
            {
                if (!isReloading)
                    StartCoroutine(ReloadGun());

                else
                    return;
            }

            if (canAttack && data.currentAmmo > 0)
            {
                CreateBullet();

                StartCoroutine(AttackCooldown(data.attackRate));
            }
        }

        protected virtual void CreateBullet()
        {
            bullet = objectPool.GetPooledObject(data.type);

            bullet.transform.position = bulletSpawn.position;

            data.currentAmmo--;
        }

        private IEnumerator ReloadGun()
        {
            isReloading = true;

            yield return new WaitForSeconds(data.reloadTime);

            isReloading = false;

            data.currentAmmo = data.maxAmmo;
        }
    }
}