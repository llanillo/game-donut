using GameCanvas;
using Templates.Managers;
using UnityEngine;

namespace Managers
{
    public class CanvasManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private GameObject canvas;

        private Canvas currentCanvas;

        private MainCanvas mainCanvas;

        private void Update()
        {
            mainCanvas.UpdateAmmo();
        }


        public ManagerStatus Status { get; private set; }

        public void Startup()
        {
            mainCanvas = canvas.GetComponentInChildren<MainCanvas>();
            mainCanvas.Startup();
        }
    }
}