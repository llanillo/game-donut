using System.Collections;
using Templates.Player;
using UnityEngine;

namespace Player.Controllers.Player_movement
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerKnockBack : MovementModifier
    {
        private bool canKnockBack = true;
        private PlayerMovement playerMove;

        protected override void OnEnable()
        {
            base.OnEnable();
            playerMove = GetComponent<PlayerMovement>();
        }

        public void AddKnockBack(Vector3 knockBackDirection, float strength, float length)
        {
            if (!canKnockBack) return;
            
            playerMove.CanMove = false;
            Value = knockBackDirection * strength;
            StartCoroutine(PlayKnockBackCooldown(length));
        }

        private IEnumerator PlayKnockBackCooldown(float length)
        {
            canKnockBack = false;

            yield return new WaitForSeconds(length);

            Value = Vector3.zero;

            playerMove.CanMove = true;

            canKnockBack = true;
        }
    }
}