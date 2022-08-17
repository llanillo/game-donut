using Managers;
using Templates.State_Machine;
using UnityEngine;

namespace Player.States
{
    public class PlayerRunState : PlayerGroundState
    {
        public PlayerRunState(PlayerManager playerManager, StateMachine stateMachine) : base(playerManager, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            playerManager.Movement.PlayerHorizontalSpeed = runSpeed;
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
                // Change to walk state if player is not pressing the run key
                if (!isRunning)
                    stateMachine.ChangeState(playerManager.WalkState);

                // Change to dodge state if player pressed the dodge key
                if (isDodging) stateMachine.ChangeState(playerManager.DodgeState);
            }
        }
    }
}