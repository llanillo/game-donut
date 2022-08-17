using System.Collections;
using Templates.Enemy.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Controllers.Dog
{
    public class DogAttController : EnemyAttackController
    {
        [SerializeField] private float attackCooldown;
        [SerializeField] private float timeBeforeAttack;
        [SerializeField] private float jumpForce;

        private NavMeshAgent agent;

        private bool canAttack = true;
        private Rigidbody rigidBody;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            rigidBody = GetComponent<Rigidbody>();
        }

        public override void Attack(Vector3 playerPosition)
        {
            if (!canAttack) return;
            agent.enabled = false;
            StartCoroutine(JumpAttack(playerPosition));
        }

        private IEnumerator JumpAttack(Vector3 playerPosition)
        {
            yield return new WaitForSecondsRealtime(timeBeforeAttack);

            var attackDirection = playerPosition - transform.position;
            attackDirection.y = 0;

            rigidBody.AddForce(attackDirection.normalized * jumpForce);
            agent.enabled = true;
            canAttack = false;
            yield return new WaitForSeconds(attackCooldown);
            canAttack = true;
        }
    }
}