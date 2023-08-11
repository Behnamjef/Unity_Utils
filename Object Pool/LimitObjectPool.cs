using UnityEngine;

namespace MagicOwl.Pool
{
    public class LimitedObjectPool<T> : ObjectPool<T> where T : Component
    {
        private readonly int _maxSize;

        public LimitedObjectPool(T prefab, int initialSize, int maxSize) : base(prefab, initialSize)
        {
            _maxSize = maxSize;
        }

        public override T GetObject()
        {
            foreach (var obj in Pool)
            {
                if(obj.gameObject.activeInHierarchy) continue;
                obj.gameObject.SetActive(true);
                return obj;
            }

            if (Pool.Count < _maxSize)
            {
                var newObj = Object.Instantiate(Prefab);
                newObj.gameObject.SetActive(true);
                Pool.Add(newObj);
                return newObj;
            }
            else
            {
                var oldestObj = Pool[0];
                Pool.RemoveAt(0);
                Pool.Add(oldestObj);
                return oldestObj;
            }
        }
    }
}