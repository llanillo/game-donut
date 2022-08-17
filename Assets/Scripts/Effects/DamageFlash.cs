using System.Collections;
using Player.Controllers.Others;
using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(PlayerHealth))]
    public class DamageFlash : MonoBehaviour
    {
        [SerializeField] private MeshRenderer mesh;

        private float flashTime;

        private PlayerHealth health;
        private Color originColor;

        private void Awake()
        {
            health = GetComponent<PlayerHealth>();
            originColor = mesh.material.color;
            flashTime = health.ImmunityTime / 2;
        }

        public void StartFlash()
        {
            StartCoroutine(Flash());
        }

        private IEnumerator Flash()
        {
            // Debug.Log("Flash happening");
            health.CanBeAttacked = false;

            for (var i = 0; i < 3; i++)
            {
                // var counter = 0;
                var material = mesh.material;
                material.color = Color.white;
                yield return new WaitForSecondsRealtime(flashTime);
                material.color = originColor;
                yield return new WaitForSecondsRealtime(flashTime);
                // Debug.Log(counter);
                // counter++;
            }

            // Debug.Log("Flash ended");
            health.CanBeAttacked = true;
        }
    }
}