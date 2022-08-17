using UnityEngine;

namespace Templates.Enemy.Controllers
{
    public abstract class EnemyAttackController : MonoBehaviour
    {
        public float triggerRadius;
        public float minDistanceToAttack;

        public virtual void Attack(Vector3 playerPosition) { }
    }
}