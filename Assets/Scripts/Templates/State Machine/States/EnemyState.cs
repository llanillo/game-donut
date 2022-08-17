using Enemy.Controllers.All;
using Templates.State_Machine;
using UnityEngine;

public abstract class EnemyState : State
{
    protected float distanceToPlayer;
    protected EnemyController enemyController;
    protected float minDistanceToAttack;

    protected Vector3 playerPosition;
    protected float remainingDistance;
    protected float triggerRadius;

    protected EnemyState(EnemyController enemyController, StateMachine stateMachine)
    {
        this.enemyController = enemyController;
        this.stateMachine = stateMachine;

        triggerRadius = enemyController.AttController.triggerRadius;
        minDistanceToAttack = enemyController.AttController.minDistanceToAttack;
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void LogicUpdate()
    {
        distanceToPlayer = enemyController.NavAgent.DistanceToPlayer;

        remainingDistance = enemyController.NavAgent.RemainingDistance;

        playerPosition = enemyController.NavAgent.PlayerPosition;
    }
}