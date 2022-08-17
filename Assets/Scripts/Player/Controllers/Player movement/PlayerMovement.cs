using Player.Controllers.Input;
using Templates.Player;
using UnityEngine;

namespace Player.Controllers.Player_movement
{
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerMovement : MovementModifier
    {
        private PlayerInputHandler inputHandler;

        private bool wasGroundedLastFrame;

        public float PlayerHorizontalSpeed { get; set; }
        public bool CanMove { get; set; }

        protected override void OnEnable()
        {
            base.OnEnable();
            inputHandler = GetComponent<PlayerInputHandler>();

            CanMove = true;
        }

        public void MovementDirection()
        {
            if (CanMove)
            {
                var playerInput = inputHandler.MovementInput;

                var playerMoveDir = new Vector3(playerInput.x, 0, playerInput.y);

                var playerMove = Vector3.ClampMagnitude(playerMoveDir, 1f);

                // Prevent player movement while falling
                if (!moveHandler.Controller.isGrounded && wasGroundedLastFrame) PlayerHorizontalSpeed = 3;

                Value = playerMove * PlayerHorizontalSpeed;

                wasGroundedLastFrame = moveHandler.Controller.isGrounded;
            }

            else
            {
                Value = Vector3.zero;
            }
        }
    }
}