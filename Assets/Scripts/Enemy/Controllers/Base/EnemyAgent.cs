using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Controllers.All
{
    public class EnemyAgent : MonoBehaviour
    {
        [SerializeField] private float rotationSmoothness;

        private Transform player;

        public NavMeshAgent Agent { get; private set; }

        public float RemainingDistance { get; private set; }
        public float DistanceToPlayer { get; private set; }

        public Vector3 PlayerPosition { get; private set; }
        public Vector3 TargetPosition { get; set; }
        public Vector3 LookDirection { get; set; }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        public void Movement()
        {
            GetTargetInfo();

            if (Agent.enabled)
                MoveToTarget();
        }

        // Rotate enemy to the direction of the target position
        private void MoveToTarget()
        {
            Agent.SetDestination(TargetPosition);
            LookTarget();
        }

        private void LookTarget()
        {
            var look = LookDirection - transform.position;
            var rotation = Quaternion.LookRotation(look);

            rotation.x = 0;
            rotation.z = 0;

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSmoothness * Time.deltaTime);
        }

        private void GetTargetInfo()
        {
            PlayerPosition = player.position;

            DistanceToPlayer = Vector3.Distance(transform.position, PlayerPosition);

            if (Agent.enabled)
                RemainingDistance = Agent.remainingDistance;
        }
    }
}