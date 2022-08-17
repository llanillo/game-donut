using Templates.Weapons.Gun;
using Templates.Weapons.Long_Range;

namespace Weapons.Guns.Grenade_Launcher
{
    public class GrenadeLauncher : Gun
    {

        protected override void CreateBullet()
        {
            base.CreateBullet();

            var grenadeScript = bullet.GetComponent<Grenade>();
            grenadeScript.ShootDirection = shootDirection;
            grenadeScript.Damage = data.damage;
            grenadeScript.DetonateTime = data.detonateTime;
            grenadeScript.ExplosionRadius = data.explosionRadius;
            grenadeScript.Force = data.force;
            grenadeScript.Length = data.length;
            grenadeScript.Height = data.throwHeight;

            bullet.SetActive(true);
        }
    }
}