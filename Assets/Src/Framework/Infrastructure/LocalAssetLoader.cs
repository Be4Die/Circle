using System.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Framework.Infrastructure
{
    public class LocalAssetLoader
    {
        private GameObject m_chachedObject;
        protected async Task<T> LoadInternal<T>(string assetId)
        {
            var handle = Addressables.InstantiateAsync(assetId);
            m_chachedObject = await handle.Task;
            if (m_chachedObject.TryGetComponent(out T component) == false)
                throw new NullReferenceException($"Object of type {typeof(T)} is null when attempt to load it from Addressables");
            
            return component;
        }

        protected void UnloadInternal()
        {
            if (m_chachedObject == null)
                return;

            m_chachedObject.SetActive(false);
            Addressables.ReleaseInstance(m_chachedObject);
            m_chachedObject = null;
        }
    }
}