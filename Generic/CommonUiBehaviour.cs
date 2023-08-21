using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MagicOwl
{
    public class CommonUIBehaviour : CommonBehaviour
    {
        protected RectTransform RectTransform => GetCachedComponentInChildren<RectTransform>();

        protected async Task RebuildAllRects()
        {
            if(gameObject.activeInHierarchy)
                StartCoroutine(RebuildUI());
        }

        public async void ResetCanvas()
        {
            gameObject.SetActive(false);
            await Task.Delay(1);
            gameObject.SetActive(true);
        }
        
        private IEnumerator RebuildUI()
        {
            yield return new WaitForEndOfFrame();
            var allRects = GetComponentsInChildren<LayoutGroup>().Select(r => r.GetComponent<RectTransform>());
            foreach (var rect in allRects)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
            }

            yield return new WaitForEndOfFrame();
            foreach (var rect in allRects)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
            }
        }
    }
}