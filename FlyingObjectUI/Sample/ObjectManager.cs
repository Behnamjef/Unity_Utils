using System;
using System.Threading.Tasks;
using DG.Tweening;
using Farbood.Model;
using MagicOwl.Utils;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Farbood
{
    public class ObjectManager : MonoBehaviour
    {
        [SerializeField] private FlyingObject FlyingObjectPrefab;
        [SerializeField] private Transform SpawnPoint;
        [SerializeField] private int ObjectCount;
        [SerializeField] private int SpawnRadious;
        [SerializeField] private Vector2 SpawnDelayRange;
        [SerializeField] private TMP_Text CounterText;

        private int _currentValue;

        private void Start()
        {
            Spawn();
        }

        public async void Spawn()
        {
            await CreateObjects();
        }

        private async Task CreateObjects()
        {
            for (int i = 0; i < ObjectCount; i++)
            {
                var randomPosition = SpawnPoint.position +
                                     Utils.GetRandomVector3(Vector3.one * SpawnRadious, Vector3.one * -SpawnRadious);
                randomPosition.z = 0;

                var flyingObject = Instantiate(FlyingObjectPrefab, randomPosition, Quaternion.identity, transform);
                flyingObject.Fly(Vector3.zero, () => UpdateText(++_currentValue));
                await Task.Delay((int)(Random.Range(SpawnDelayRange.x, SpawnDelayRange.y) * 1000));
            }
        }

        private void UpdateText(int newVale)
        {
            _currentValue = newVale;
            CounterText.SetText(newVale.ToString());
            transform.DOScale(0.8f, 0.1f).From(1).SetLoops(2, LoopType.Yoyo);
        }
    }
}