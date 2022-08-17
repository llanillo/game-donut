using Effects;
using Player.Data;
using UnityEngine;

namespace Player.Controllers.Others
{
    [RequireComponent(typeof(DamageFlash))]
    public class PlayerHealth : MonoBehaviour
    {
        public delegate void UpdateCanvasDelegate(float damage);

        [SerializeField] private PlayerData playerData;

        private DamageFlash damageFlash;

        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }
        public float ImmunityTime { get; private set; }

        public bool CanBeAttacked { get; set; }

        private void Awake()
        {
            AsignVariables();
        }

        public event UpdateCanvasDelegate HeartsDelegate;

        public void ReduceHealth(float damage)
        {
            if (CanBeAttacked && CurrentHealth > 0)
            {
                CurrentHealth -= damage;

                // Updates canvas hearts
                if (HeartsDelegate != null)
                    HeartsDelegate(damage);

                // Start flash damage blink
                damageFlash.StartFlash();
            }

            if (CurrentHealth <= 0)
                Debug.Log("Player death");
        }

        public void Heal(float healing)
        {
            CurrentHealth += healing;

            if (CurrentHealth >= MaxHealth)
                CurrentHealth = MaxHealth;
        }

        private void AsignVariables()
        {
            damageFlash = GetComponent<DamageFlash>();

            CurrentHealth = playerData.health;
            MaxHealth = playerData.maxHealth;

            ImmunityTime = playerData.immunityTime;
            CanBeAttacked = true;
        }
    }
}