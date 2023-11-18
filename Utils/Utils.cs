using UnityEngine;

namespace MagicOwl.Utils
{
    public static class Utils
    {
        public static Vector3 GetRandomVector3(Vector3 a, Vector3 b)
        {
            var x = Random.Range(a.x, b.x);
            var y = Random.Range(a.y, b.y);
            var z = Random.Range(a.z, b.z);

            return new Vector3(x, y, z);
        }

    }
}