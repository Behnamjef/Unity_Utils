using DG.Tweening;
using UnityEngine;

namespace MagicOwl.Utils
{
    public class ShakeOnTrigger : MonoBehaviour
    {
        [SerializeField] private float ShakeDuration = 0.2f;
        [SerializeField] private float ShakePower = 0.2f;
        [SerializeField] private int VibrateCount = 20;

        private void OnTriggerEnter(Collider other)
        {
            var direction = transform.position - other.transform.position;
            direction.y = 0;
            transform.DOComplete(); // Complete Previous Animation
            transform.DOShakePosition(ShakeDuration, direction.normalized * ShakePower, VibrateCount);
        }
    }
}