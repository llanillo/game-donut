using Templates.Weapons.Base;
using UnityEngine;

namespace Weapons.Swords.Basic_Sword
{
    public class BasicSword : Weapon
    {
        private Animator anim;
        private BoxCollider swordCollider;
        private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

        private void Awake()
        {
            GetComponents();
        }

        public override void Attack(Vector3 attackDirection)
        {
            base.Attack(attackDirection);
            anim.SetBool(IsAttacking, true);
            swordCollider.enabled = true;
        }

        // It is called from the sword animation when it finishes the swing
        private void CancelAttackAnimEvent()
        {
            anim.SetBool(IsAttacking, false);
        }

        private void GetComponents()
        {
            anim = GetComponent<Animator>();
            swordCollider = GetComponent<BoxCollider>();
            swordCollider.enabled = false;
        }
    }
}