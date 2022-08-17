using Templates.Player;
using UnityEngine;

namespace Player.Controllers.Player_movement
{
    public class PlayerFall : MovementModifier
    {
        private const float GravityPull = -0.75f;
        private readonly float gravity = Physics.gravity.y;

        private Vector3 playerHorVel;

        public void Gravity()
        {
            if (moveHandler.Controller.isGrounded) // Pushes player down a little to the ground
                playerHorVel.y = GravityPull;

            else
                playerHorVel.y += gravity * Time.deltaTime;

            Value = playerHorVel;
        }
    }
}