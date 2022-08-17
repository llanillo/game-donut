using Managers;
using Templates.State_Machine;
using UnityEngine;

namespace Player.States
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(PlayerManager playerManager, StateMachine stateMachine) : base(playerManager, stateMachine)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            // Check if player is pressing movement keys
            if (playerInput.Equals(Vector2.zero)) return;
            switch (playerManager.InputHandler.IsRunning)
            {
                // Checks player current speed to change to walk or run state
                case false:
                    stateMachine.ChangeState(playerManager.WalkState);
                    break;
                case true:
                    stateMachine.ChangeState(playerManager.RunState);
                    break;
            }
        }
    }
}