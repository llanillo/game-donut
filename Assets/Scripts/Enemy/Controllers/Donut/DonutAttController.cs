using System.Collections;
using Templates.Enemy.Controllers;
using UnityEngine;
using Weapons.Swords.Basic_Sword.Enemy;

namespace Enemy.Controllers.Donut
{
    public class DonutAttController : EnemyAttackController
    {
        [SerializeField] private float attackCooldown;
        [SerializeField] private float swordForce;

        private bool canAttack = true;

        private EnemySword donutSword;

        private void Awake()
        {
            donutSword = GetComponentInChildren<EnemySword>();
        }

        public override void Attack(Vector3 playerPosition)
        {
            if (!canAttack) return;
            donutSword.Attack(playerPosition);
            StartCoroutine(AttackCooldown());
        }

        private IEnumerator AttackCooldown()
        {
            canAttack = false;
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }
    }
}