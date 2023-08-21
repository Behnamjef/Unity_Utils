using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace MagicOwl
{
    public class CommonBehaviour : MonoBehaviour
    {
        private Dictionary<string, Component> _cachedComponents;
        private Dictionary<string, Component> cachedComponents
        {
            get
            {
                if(_cachedComponents == null)
                {
                    _cachedComponents = new Dictionary<string, Component>();
                }

                return _cachedComponents;
            }
        }

        private CancellationTokenSource _initCancellationTokenSource;
        
        /// <summary>
        /// This token source is used for preventing any conflict when a new init is triggered in the middle of a previous one.
        /// </summary>
        protected CancellationTokenSource initCancellationTokenSource
        {
            get
            {
                if(_initCancellationTokenSource == null)
                {
                    _initCancellationTokenSource = new CancellationTokenSource();
                }
                
                return _initCancellationTokenSource;
            }
        }

        /// <summary>
        /// Cancels any previous init operation on this menu section.
        /// The use of this feature is optional for any menu section, but it is recommended for any menu section that uses async operation for its initialization.
        /// </summary>
        protected void CancelPreviousInitOperation()
        {
            _initCancellationTokenSource?.Cancel();
            _initCancellationTokenSource?.Dispose();
            _initCancellationTokenSource = null;
        }

        protected virtual void OnDestroy()
        {
            CancelPreviousInitOperation();
        }

        public T GetCachedComponent<T>() where T : Component
        {
            var cachedComponents = this.cachedComponents;
            
            var typeName = GetCachedTypeName<T>();
            T result = null;

            if(cachedComponents.ContainsKey(typeName))
            {
                result = cachedComponents[typeName] as T;
            }

            if(!result)
            {
                result = GetComponent<T>();
                if(result)
                {
                    cachedComponents[typeName] = result;
                }
            }

            return result;
        }

        public T GetCachedComponentInChildren<T>(bool includeInactive = true) where T : class
        {
            return GetCachedComponentInChildren(typeof(T), includeInactive) as T;
        }

        public Component GetCachedComponentInChildren(Type componentType)
        {
            return GetCachedComponentInChildren(componentType, true);
        }
        
        public Component GetCachedComponentInChildren(Type componentType, bool includeInactive = true)
        {
            var cachedComponents = this.cachedComponents;

            var typeName = GetCachedTypeName(componentType);
            Component result = null;

            if(cachedComponents.ContainsKey(typeName))
            {
                result = cachedComponents[typeName];
            }

            if(!result)
            {
                result = GetComponentInChildren(componentType, includeInactive);
                if(result)
                {
                    cachedComponents[typeName] = result;
                }
            }

            return result;
        }

        private string GetCachedTypeName(Type componentType)
        {
            return componentType.Name;
        }
        private string GetCachedTypeName<T>()
        {
            return GetCachedTypeName(typeof(T));
        }

        public virtual void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
        
        public bool IsOperationCanceled()
        {
            return _initCancellationTokenSource == null;
        }
    }
}