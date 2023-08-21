using System;
using UnityEngine;

namespace MagicOwl
{
    
    public class InternetManager : MonoBehaviour
    {
        [SerializeField] private InternetChecker InternetChecker;
        
        private async void Start()
        {
            var isOnline = await InternetChecker.CheckNetwork();
            Debug.Log($"Is online: {isOnline}");
        }
    }
}