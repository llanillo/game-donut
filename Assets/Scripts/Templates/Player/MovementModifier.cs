using Player.Controllers.Player_movement;
using UnityEngine;

namespace Templates.Player
{
    [RequireComponent(typeof(MovementHandler))]
    public abstract class MovementModifier : MonoBehaviour
    {
        protected MovementHandler moveHandler;

        public Vector3 Value { get; protected set; }

        protected virtual void OnEnable()
        {
            moveHandler = GetComponent<MovementHandler>();
            moveHandler.moveModifiers.Add(this);
        }

        private void OnDisable()
        {
            moveHandler.moveModifiers.Add(this);
        }
    }
}