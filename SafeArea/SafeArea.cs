using UnityEngine;

namespace MagicOwl
{
    public class SafeArea : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            ApplySafeArea();
        }

        private void ApplySafeArea()
        {
            var safeArea = Screen.safeArea;

            // Convert safe area values to canvas space
            var minAnchor = safeArea.position;
            var maxAnchor = safeArea.position + safeArea.size;
            minAnchor.x /= Screen.width;
            minAnchor.y /= Screen.height;
            maxAnchor.x /= Screen.width;
            maxAnchor.y /= Screen.height;

            // Apply the safe area to the RectTransform
            _rectTransform.anchorMin = minAnchor;
            _rectTransform.anchorMax = maxAnchor;
        }
    }
}

