using System;
using UnityEngine;

namespace MagicOwl.Pool.Sample
{
    public class Bullet : MonoBehaviour
    {
        private float Speed;
        public Action<Bullet> OnStop;

        public void Shoot(float speed, float lifeTime)
        {
            Speed = speed;
            Invoke(nameof(Stop), lifeTime);
        }

        private void Stop()
        {
            Speed = 0;
            OnStop?.Invoke(this);
        }

        private void FixedUpdate()
        {
            transform.position += transform.forward * Speed;
        }
    }
}