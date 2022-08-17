using System.Collections;
using Managers;
using Templates.Player;
using UnityEngine;

namespace Player.Controllers.Player_movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerDodge : MovementModifier
    {
        private bool canDodge = true;
        private CharacterController controller;
        private float dodgeCooldown;
        private float dodgeLength;

        private float dodgeSpeed;
        private PlayerManager playerManager;

        // Start is called before the first frame update
        private void Start()
        {
            controller = GetComponent<CharacterController>();
            playerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerManager>();

            dodgeSpeed = playerManager.playerData.dodgeSpeed;
            dodgeLength = playerManager.playerData.dodgeLength;
            dodgeCooldown = playerManager.playerData.dodgeCooldown;
        }

        public void DodgeDirection()
        {
            if (canDodge)
            {
                var lastPlayerDirection = Vector3.Normalize(controller.velocity);

                Value = lastPlayerDirection * dodgeSpeed;

                DodgeCooldown();
            }
        }

        private void DodgeCooldown()
        {
            StartCoroutine(ResetDodge());
        }

        private IEnumerator ResetDodge()
        {
            canDodge = false;
            playerManager.Health.CanBeAttacked = false;

            yield return new WaitForSeconds(dodgeLength);

            Value = Vector3.zero;
            playerManager.Health.CanBeAttacked = true;

            yield return new WaitForSeconds(dodgeCooldown);

            canDodge = true;
        }
    }
}