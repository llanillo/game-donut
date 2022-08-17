using System.Collections;
using Enemy.Data;
using UnityEngine;

namespace Enemy.Controllers.All
{
    public class EnemyHealth : MonoBehaviour
    {
        private bool canBeAttacked = true;
        private EnemyData enemyData;

        private float health;
        private float immunityTime;

        private void Awake()
        {
            enemyData = GetComponent<EnemyController>().EnemyData;
            health = enemyData.maxHealth;
            immunityTime = enemyData.immunityTime;
        }

        public void ReduceHealth(float damage)
        {
            if (canBeAttacked && health > 0) health -= damage;

            if (health <= 0)
                Debug.Log("Enemy death");
        }

        private IEnumerator AttackedCooldown()
        {
            canBeAttacked = false;
            yield return new WaitForSeconds(immunityTime);
            canBeAttacked = true;
        }
    }
}