using System.Collections;
using System.Collections.Generic;
using Templates.Managers;
using UnityEngine;

namespace Managers
{
    public class Managers : MonoBehaviour
    {
        private List<IGameManager> startSequence;
        public PlayerManager PlayerManager { get; private set; }
        public ObjectPool ObjectPools { get; private set; }
        public CanvasManager CanvasManager { get; private set; }

        private void Awake()
        {
            PlayerManager = GetComponent<PlayerManager>();
            ObjectPools = GetComponent<ObjectPool>();
            CanvasManager = GetComponent<CanvasManager>();

            startSequence = new List<IGameManager>
            {
                PlayerManager,
                ObjectPools,
                CanvasManager
            };

            StartCoroutine(StartupManagers());
        }

        private IEnumerator StartupManagers()
        {
            foreach (var manager in startSequence) manager.Startup();

            yield return null;

            var numModules = startSequence.Count;
            var numReady = 0;

            while (numReady < numModules)
            {
                var lastReady = numReady;
                numReady = 0;

                foreach (var manager in startSequence)
                    if (manager.Status == ManagerStatus.Started)
                        numReady++;

                if (numReady > lastReady)
                    Debug.Log("Progress: " + numReady + "/" + numModules);

                yield return null;
            }

            Debug.Log("All managers started up");
        }
    }
}