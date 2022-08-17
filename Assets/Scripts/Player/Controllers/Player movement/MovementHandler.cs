using System.Collections.Generic;
using Templates.Player;
using UnityEngine;

namespace Player.Controllers.Player_movement
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementHandler : MonoBehaviour
    {
        public readonly List<MovementModifier> moveModifiers = new();

        public CharacterController Controller { get; private set; }

        private void Start()
        {
            Controller = GetComponent<CharacterController>();
        }

        public void Move()
        {
            var movement = Vector3.zero;

            foreach (var modifier in moveModifiers) movement += modifier.Value;

            Controller.Move(movement * Time.deltaTime);
        }
    }
}