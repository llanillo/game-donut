using Managers;
using Templates.State_Machine;
using UnityEngine;

namespace Player.States
{
    public class PlayerFallState : PlayerState
    {
        public PlayerFallState(PlayerManager playerManager, StateMachine stateMachine) : base(playerManager, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isGrounded) return;
            // Check if player is pressing movement keys
            if (!playerInput.Equals(Vector2.zero))
            {
                switch (isRunning)
                {
                    // Checks if player is pressing the run key
                    case false:
                        stateMachine.ChangeState(playerManager.WalkState);
                        break;
                    case true:
                        stateMachine.ChangeState(playerManager.RunState);
                        break;
                }
            }

            else
            {
                stateMachine.ChangeState(playerManager.IdleState);
            }
        }
    }
}