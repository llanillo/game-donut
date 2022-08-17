using Managers;
using Templates.State_Machine;
using UnityEngine;

namespace Player.States
{
    public class PlayerWalkState : PlayerGroundState
    {
        public PlayerWalkState(PlayerManager playerManager, StateMachine stateMachine) : base(playerManager, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            playerManager.Movement.PlayerHorizontalSpeed = walkSpeed;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            // Check if player is not pressing movement keys
            if (playerInput.Equals(Vector2.zero))
            {
                stateMachine.ChangeState(playerManager.IdleState);
            }

            else
            {
                // Change to run state if player is pressing the run key
                if (isRunning)
                    stateMachine.ChangeState(playerManager.RunState);

                // Change to dodge state if player pressed the dodge key
                if (isDodging) stateMachine.ChangeState(playerManager.DodgeState);
            }
        }
    }
}