using UnityEngine;

namespace MagicOwl
{
    public class DontDestroySingletonBehaviour<T> : SingletonBehaviour<T> where T : MonoBehaviour
    {
        public override void Init()
        {
            base.Init();
            DontDestroyOnLoad(this);
        }
    }
}
