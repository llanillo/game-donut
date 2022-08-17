using Player.Controllers.Input;
using Player.Controllers.Player_movement;
using Templates.Weapons.Base;
using UnityEngine;

namespace Player.Controllers.Others
{
    public class AttackController : MonoBehaviour
    {
        private PlayerInputHandler input;
        private PlayerRotation rotation;
        public Weapon CurrentWeapon { get; set; }

        private void Awake()
        {
            input = GetComponent<PlayerInputHandler>();
            rotation = GetComponent<PlayerRotation>();
        }

        private void Update()
        {
            if (CurrentWeapon == null) return;
            if (CurrentWeapon.isGun)
                Attack();
            else
                Debug.Log("weapon controller updatte else");
        }

        private void Attack()
        {
            if (!input.IsAttacking) return;
            var shootDirection = rotation.LookDirection.normalized;

            CurrentWeapon.Attack(shootDirection);
        }
    }
}