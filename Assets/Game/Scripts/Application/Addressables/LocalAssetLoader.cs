using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SampleGame
{
    [UsedImplicitly]
    public sealed class LocalAssetLoader
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

        public bool Unload(string id)
        {
            var result = Addressables.ReleaseInstance(_gameObjects[id]);
            
            if (result)
                _gameObjects.Remove(id);
            else
                Debug.LogWarning($"Failed to unload asset with ID: {id}, the asset has already been unloaded");
            
            return result;
        }
    }
}