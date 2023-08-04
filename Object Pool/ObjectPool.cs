using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MagicOwl.Pool
{
    public class ObjectPool<T> where T : Component
    {
        protected readonly List<T> Pool;
        protected readonly T Prefab;

        public ObjectPool(T prefab, int initialSize)
        {
            Prefab = prefab;

            Pool = new List<T>();
            for (var i = 0; i < initialSize; i++)
            {
                var obj = Object.Instantiate(prefab);
                obj.gameObject.SetActive(false);
                Pool.Add(obj);
            }
        }

        public virtual T GetObject()
        {
            foreach (var obj in Pool.Where(obj => !obj.gameObject.activeInHierarchy))
            {
                obj.gameObject.SetActive(true);
                return obj;
            }

            var newObj = Object.Instantiate(Prefab);
            newObj.gameObject.SetActive(true);
            Pool.Add(newObj);
            return newObj;
        }

        public void ReleaseObject(T obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}