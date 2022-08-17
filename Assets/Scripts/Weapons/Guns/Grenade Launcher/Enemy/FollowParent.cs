using UnityEngine;

namespace Weapons.Guns.Grenade_Launcher.Enemy
{
    public class FollowParent : MonoBehaviour
    {
        [SerializeField] private GameObject parent;

        private readonly Vector3 offsetY = Vector3.up * 1.5f;
        private Quaternion initial;

        private void Awake()
        {
            initial = transform.rotation;
        }

        // Update is called once per frame
        private void Update()
        {
            var currentTransform = transform;
            currentTransform.position = parent.transform.position + offsetY;
            currentTransform.rotation = initial;
        }
    }
}