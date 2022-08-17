using Managers;
using Templates.State_Machine;

namespace Player.States
{
    public class PlayerGroundState : PlayerState
    {
        protected readonly float runSpeed;
        protected readonly float walkSpeed;

        protected PlayerGroundState(PlayerManager playerManager, StateMachine stateMachine) : base(playerManager, stateMachine)
        {
            walkSpeed = playerManager.playerData.baseSpeed;
            runSpeed = playerManager.playerData.runSpeed;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            // Changes to falling state if player is not touching the ground
            if (!isGrounded) stateMachine.ChangeState(playerManager.FallingState);
        }
    }
}