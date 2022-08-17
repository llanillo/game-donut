using Player.Controllers.Others;
using Player.Controllers.Player_movement;
using UnityEngine;

namespace Weapons.Swords.Basic_Sword.Enemy
{
    public class EnemySword : BasicSword
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            other.GetComponent<PlayerHealth>().ReduceHealth(data.damage);
            AddKnockBack(other);
        }

        private void AddKnockBack(Collider colliderObj)
        {
            var playerPosition = colliderObj.transform.position;
            var knockBackDirection = playerPosition - transform.position;
            knockBackDirection.y = 0;

            var player = colliderObj.GetComponent<PlayerKnockBack>();
            player.AddKnockBack(knockBackDirection.normalized, 2, 0.5f);
        }
    }
}