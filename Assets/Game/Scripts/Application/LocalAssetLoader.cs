using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SampleGame
{
    [UsedImplicitly]
    public class LocalAssetLoader
    {
        public readonly Dictionary<string,GameObject> _gameObjects=new ();
        
        public async Task Load<T>(string id)
        {
            if (_gameObjects.ContainsKey(id)) return;
            
            var handle = Addressables.LoadAssetAsync<T>(id);
            await handle.Task;

            if (handle is { Status: AsyncOperationStatus.Succeeded, Result: GameObject gameObject })
            {
                _gameObjects.Add(id,gameObject);
            }
            else
            {
                Debug.LogError($"Failed to load asset with ID: {id}");
            }

            Addressables.Release(handle);
        }

        public void Unload<T>()
        {
            
        }
    }
}