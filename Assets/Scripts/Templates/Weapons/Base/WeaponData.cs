using Templates.Weapons.Long_Range;
using UnityEngine;

namespace Templates.Weapons.Base
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [Header("Basic")] public float damage;

        public float attackRate;

        [Header("Long distance attacks")] public PoolTag type;

        [Header("Bullet (Only guns)")] public int currentAmmo;

        public int maxAmmo;
        public float reloadTime;
        public float bulletSpeed;

        [Header("Throwable (Only explosives)")]
        public float detonateTime;

        public float explosionRadius;
        public float force;
        public float length;
        public float throwHeight;
    }
}