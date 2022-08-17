using System.Collections;
using Player.Controllers.Input;
using Templates.Weapons.Base;
using UnityEngine;

namespace Player.Controllers.Others
{
    public class WeaponSwitch : MonoBehaviour
    {
        [SerializeField] private int maxActiveWeapons;
        [SerializeField] private float switchCooldown;
        [SerializeField] private Transform weaponHolder;

        private AttackController attController;
        private bool canSwitch = true;
        private PlayerInputHandler input;

        private int selectedWeapon;

        private void Awake()
        {
            input = GetComponent<PlayerInputHandler>();
            attController = GetComponent<AttackController>();
        }

        public void EquipWeapon(Transform gunOnGround)
        {
            var counter = 0;

            // Checks if weapon is already equipped
            foreach (Transform weapon in weaponHolder)
                if (weapon.name.Equals(gunOnGround.name))
                    counter++;

            if (counter == 0 && MaxActiveWeapons())
            {
                var equippedWeapon = attController.CurrentWeapon;

                // If player doesnt have any weapon
                if (equippedWeapon != null)
                    equippedWeapon.gameObject.SetActive(false);

                gunOnGround.rotation = Quaternion.Euler(0, 0, 0);
                gunOnGround.forward = weaponHolder.forward;
                gunOnGround.position = weaponHolder.position;
                gunOnGround.parent = weaponHolder;

                attController.CurrentWeapon = gunOnGround.GetComponent<Weapon>();
            }
            else
            {
                Debug.Log("Cant equip");
            }
        }

        public void OnSwichWeaponInput()
        {
            var previousSelectedWeapon = selectedWeapon;

            if (canSwitch)
            {
                if (input.IsSwitchingByScroll > 0f || input.IsSwitchingByKey)
                {
                    if (selectedWeapon >= weaponHolder.childCount - 1)
                        selectedWeapon = 0;
                    else
                        selectedWeapon++;
                }

                if (input.IsSwitchingByScroll < 0f)
                {
                    if (selectedWeapon <= 0)
                        selectedWeapon = weaponHolder.childCount - 1;
                    else
                        selectedWeapon--;
                }

                if (previousSelectedWeapon != selectedWeapon)
                {
                    SwitchWeapon();
                    SwitchWeapnCooldown();
                }
            }
        }

        private void SwitchWeapon()
        {
            var equippedWeapon = attController.CurrentWeapon;

            if (!input.IsAttacking)
                if (equippedWeapon != null)
                {
                    var i = 0;

                    foreach (Transform weapon in weaponHolder)
                    {
                        if (i == selectedWeapon)
                        {
                            attController.CurrentWeapon = weapon.GetComponent<Weapon>();
                            weapon.gameObject.SetActive(true);
                        }

                        else
                        {
                            weapon.gameObject.SetActive(false);
                        }

                        i++;
                    }
                }
        }

        private void SwitchWeapnCooldown()
        {
            if (canSwitch)
                StartCoroutine(ResetSwitchInput());
            else
                return;
        }

        private IEnumerator ResetSwitchInput()
        {
            canSwitch = false;

            yield return new WaitForSecondsRealtime(switchCooldown);

            canSwitch = true;
        }

        private bool MaxActiveWeapons()
        {
            return weaponHolder.childCount <= maxActiveWeapons ? true : false;
        }
    }
}