using Enemy.Controllers.All;
using Templates.State_Machine;
using UnityEngine;

namespace Enemy.States
{
    public class EnemyPatrolState : EnemyState
    {
        private int patrolTargetCount;
        private int targetNumber;

        public EnemyPatrolState(EnemyController enemyController, StateMachine stateMachine) : base(enemyController,
            stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            patrolTargetCount = enemyController.PatrolTargets.Count;

            RandomizePatrol();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (remainingDistance <= 1f) RandomizePatrol();

            if (distanceToPlayer <= triggerRadius) stateMachine.ChangeState(enemyController.ChaseState);
        }

        private void RandomizePatrol()
        {
            targetNumber = Random.Range(0, patrolTargetCount);

            enemyController.NavAgent.TargetPosition = enemyController.PatrolTargets[targetNumber].position;

            enemyController.NavAgent.LookDirection = enemyController.NavAgent.TargetPosition;
        }
    }
}