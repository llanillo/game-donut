using System;
using Templates.Weapons.Long_Range;
using UnityEngine;

namespace Managers
{
    [Serializable]
    public class Pool
    {
        public PoolTag tag;
        public GameObject objectToPool;
        public int size;
    }
}