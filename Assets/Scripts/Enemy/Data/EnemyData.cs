using UnityEngine;

namespace Enemy.Data
{
    [CreateAssetMenu(fileName = "newCharacterData", menuName = "Data/Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [Header("Health")] public float maxHealth;

        public float immunityTime;

        [Header("Movement")] public float baseSpeed;

        public float runSpeed;
    }
}