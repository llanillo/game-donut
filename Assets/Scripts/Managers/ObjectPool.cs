using System.Collections.Generic;
using Templates.Managers;
using Templates.Weapons.Long_Range;
using UnityEngine;

namespace Managers
{
    public class ObjectPool : MonoBehaviour, IGameManager
    {
        [SerializeField] private List<Pool> pools;
        private Dictionary<PoolTag, Queue<GameObject>> poolDictionary;

        public ManagerStatus Status { get; }

        public void Startup()
        {
            Debug.Log("Object pooler starting...");
            CreatePools();
        }

        private void CreatePools()
        {
            poolDictionary = new Dictionary<PoolTag, Queue<GameObject>>();

            foreach (var pool in pools)
            {
                var objectPool = new Queue<GameObject>();

                for (var i = 0; i < pool.size; i++)
                {
                    var obj = Instantiate(pool.objectToPool);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject GetPooledObject(PoolTag tag)
        {
            var objToSpawn = poolDictionary[tag].Dequeue();

            objToSpawn.SetActive(false);

            poolDictionary[tag].Enqueue(objToSpawn);

            return objToSpawn;
        }

    }
}