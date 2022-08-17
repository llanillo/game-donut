using System.Collections;
using Managers;
using UnityEngine;

namespace Templates.Weapons.Base
{
    public abstract class Weapon : MonoBehaviour
    {
        public WeaponData data;
        public bool isGun;
        protected bool canAttack = true;
        protected ObjectPool objectPool;

        private void Start()
        {
            var gameController = GameObject.FindGameObjectWithTag("GameController");
            objectPool = gameController.GetComponent<ObjectPool>();
        }

        public virtual void Attack(Vector3 attackDirection)
        {
        }

        protected IEnumerator AttackCooldown(float attackRate)
        {
            canAttack = false;

            yield return new WaitForSeconds(attackRate);

            canAttack = true;
        }
    }
}