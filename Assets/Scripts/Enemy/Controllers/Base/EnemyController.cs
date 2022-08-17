using System.Collections.Generic;
using Enemy.Data;
using Enemy.States;
using Templates.Enemy.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Controllers.All
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAttackController))]
    [RequireComponent(typeof(EnemyHealth))]
    [RequireComponent(typeof(EnemyAgent))]
    public class EnemyController : MonoBehaviour
    {
        public List<Transform> PatrolTargets { get; private set; }

        private void Awake()
        {
            // Creates new object of the player state machine
            stateMachine = new EnemyStateMachine();

            AttController = GetComponent<EnemyAttackController>();
            Health = GetComponent<EnemyHealth>();
            NavAgent = GetComponentInParent<EnemyAgent>();

            AttackState = new EnemyAttackState(this, stateMachine);
            ChaseState = new EnemyChaseState(this, stateMachine);
            PatrolState = new EnemyPatrolState(this, stateMachine);
        }

        // Start is called before the first frame update
        private void Start()
        {
            ConfigurePatrolTargets();
            stateMachine.Initialize(PatrolState);
        }

        // Update is called once per frame
        private void Update()
        {
            NavAgent.Movement();
            stateMachine.CurrentState.LogicUpdate();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, AttController.triggerRadius);
        }

        private void ConfigurePatrolTargets()
        {
            PatrolTargets = new List<Transform>();

            var childPatrol = transform.Find("Patrol Targets");

            foreach (Transform child in childPatrol) PatrolTargets.Add(child);

            foreach (var child in PatrolTargets) child.SetParent(null, true);
        }

        public EnemyData EnemyData;

        public EnemyAttackController AttController { get; private set; }
        public EnemyHealth Health { get; private set; }
        public EnemyAgent NavAgent { get; private set; }


        private EnemyStateMachine stateMachine;

        public EnemyAttackState AttackState { get; private set; }
        public EnemyChaseState ChaseState { get; private set; }
        public EnemyPatrolState PatrolState { get; private set; }
    }
}