using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace MagicOwl.Utils
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        public static bool HasIndex<T>(this IEnumerable<T> enumerable, int index)
        {
            return index >= 0 && !enumerable.IsNullOrEmpty() && enumerable.Count() > index;
        }

        public static T GetRandomItem<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToList()[UnityEngine.Random.Range(0, enumerable.Count())];
        }

        public static IEnumerable<T> GetRandomItems<T>(this IEnumerable<T> enumerable, int count)
        {
            return enumerable.OrderBy(x => Guid.NewGuid()).Take(count);
        }

        public static IEnumerable<T> GetUniqueRandomItems<T>(this IEnumerable<T> enumerable, int count)
        {
            if (count <= 0)
                throw new ArgumentException("Count must be greater than 0");

            var collection = enumerable.ToList();
            var rng = new System.Random(DateTime.Now.Millisecond);

            if (count > collection.Count)
                count = collection.Count;
            
            for (int i = 0; i < count; i++)
            {
                var index = rng.Next(collection.Count);
                var item = collection[index];
                yield return item;
                collection.RemoveAt(index);
            }
        }

        public static void SetGlobalScale(this Transform transform, Vector3 globalScale)
        {
            transform.localScale = Vector3.one;
            transform.localScale = new Vector3(globalScale.x / transform.lossyScale.x,
                globalScale.y / transform.lossyScale.y, globalScale.z / transform.lossyScale.z);
        }

        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static T AddOrGetComponent<T>(this GameObject source) where T : Component
        {
            var obj = source.GetComponent<T>();
            if (obj == null)
                obj = source.AddComponent<T>();
            return obj;
        }
    }
}
