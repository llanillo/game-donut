using Templates.Enemy.Controllers;
using UnityEngine;
using Weapons.Guns.Basic_Gun;
using Weapons.Guns.Grenade_Launcher;

namespace Enemy.Controllers.Police
{
    public class PoliceAttController : EnemyAttackController
    {
        private Vector3 playerDirection;
        private BasicGun policeGun;
        private GrenadeLauncher policeLauncher;

        private void Awake()
        {
            policeGun = GetComponentInChildren<BasicGun>();
            policeLauncher = GetComponentInChildren<GrenadeLauncher>();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, triggerRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, minDistanceToAttack);
        }

        public override void Attack(Vector3 playerPosition)
        {
            var shortRange = minDistanceToAttack / 1.2f;
            var distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

            if (distanceToPlayer >= shortRange)
            {
                playerDirection = playerPosition - policeGun.bulletSpawn.position;
                policeLauncher.Attack(playerDirection);
            }

            else
            {
                playerDirection = Vector3.Normalize(playerPosition - policeGun.bulletSpawn.position);
                policeGun.Attack(playerDirection);
            }
        }
    }
}