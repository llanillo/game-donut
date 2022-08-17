using Player.Controllers.Others;
using UnityEngine;

namespace Player
{
    public class WeaponPickUp : MonoBehaviour
    {
        private WeaponSwitch playerWeaponSwitch;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            playerWeaponSwitch = other.GetComponent<WeaponSwitch>();
            playerWeaponSwitch.EquipWeapon(transform);
            Destroy(this);
        }
    }
}