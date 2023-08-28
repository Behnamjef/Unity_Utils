using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Farbood.Model
{
    public class FlyingObject : MonoBehaviour
    {
        private Camera Camera => Camera.main;

        public async Task Fly(Vector3 localDestination, Action onFlyComplete)
        {
            transform.DOKill();

            transform.DOLocalMove(localDestination, 1f).SetEase(Ease.InBack);
            await transform.DOScale(.7f, 0.3f).SetEase(Ease.OutBounce).From(Vector3.zero).AsyncWaitForCompletion();
            await transform.DOScale(0.5f, 0.7f).AsyncWaitForCompletion();

            onFlyComplete?.Invoke();
            Destroy(gameObject);
        }
    }
}