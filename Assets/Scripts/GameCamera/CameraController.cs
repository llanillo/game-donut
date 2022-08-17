using UnityEngine;

namespace GameCamera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float smoothTime = .3f;
        private readonly Vector3 offset = new(0, 9, -7);

        private Transform target;
        private Vector3 velocity = Vector3.zero;

        private void Start()
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            var desiredPosition = target.position + offset;
            var smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

            transform.position = smoothedPosition;
        }
    }
}