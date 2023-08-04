using System.Collections;
using UnityEngine;

namespace MagicOwl.Pool.Sample
{
    public class BulletGenerator : MonoBehaviour
    {
        [SerializeField] private float BulletsSpeed;
        [SerializeField] private float BulletsLifeTime;
        [SerializeField] private float FireRate;
        [SerializeField] private Bullet BulletPrefab;
        [SerializeField] private int MaxBulletAllowed;
        private LimitedObjectPool<Bullet> _bulletPool;

        private void Start()
        {
            _bulletPool = new LimitedObjectPool<Bullet>(BulletPrefab, MaxBulletAllowed / 2, MaxBulletAllowed);

            StartCoroutine(StartShoot());
        }

        private IEnumerator StartShoot()
        {
            while (true)
            {
                if (FireRate < 0.1f)
                    FireRate = 0.1f;

                yield return new WaitForSeconds(1f / FireRate);
                CreateNewBullet(transform.position, transform.forward);
            }
        }

        private void CreateNewBullet(Vector3 position, Vector3 forward)
        {
            var bullet = _bulletPool.GetObject();

            bullet.OnStop = OnBulletStopped;
            bullet.transform.position = position;
            bullet.transform.forward = forward;
            bullet.Shoot(BulletsSpeed, BulletsLifeTime);
        }

        private void OnBulletStopped(Bullet bullet)
        {
            _bulletPool.ReleaseObject(bullet);
        }
    }
}