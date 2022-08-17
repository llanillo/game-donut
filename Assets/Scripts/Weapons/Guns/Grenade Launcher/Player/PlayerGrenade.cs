using Enemy.Controllers.All;
using Templates.Weapons.Long_Range;
using UnityEngine;

public class PlayerGrenade : Grenade
{
    private EnemyHealth enemyHealth;

    protected override void OnEnable()
    {
        ShootDirection *= 15;
        base.OnEnable();
    }

    // Explodes immediately if players touch the grenade
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) StartCoroutine(Explosion(0));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }

    protected override void HandleCollisions()
    {
        base.HandleCollisions();

        foreach (var collider in colliders)
            if (collider.CompareTag("Enemy"))
            {
                enemyHealth = collider.GetComponent<EnemyHealth>();
                enemyHealth.ReduceHealth(Damage);
            }
    }
}