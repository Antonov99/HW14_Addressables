using JetBrains.Annotations;
using SampleGame;
using UnityEngine;
using Zenject;

namespace Game.Scripts
{
    [UsedImplicitly]
    public class Factory
    {
        private LocalAssetLoader _localAssetLoader;
        private DiContainer _diContainer;

        [Inject]
        public void Construct(LocalAssetLoader localAssetLoader, DiContainer diContainer)
        {
            _localAssetLoader = localAssetLoader;
            _diContainer = diContainer;
        }

        public T InstantiateObject<T>(string id, Transform parent)
        {
            var instance = _diContainer.InstantiatePrefab(_localAssetLoader._gameObjects[id], parent);

            T component = instance.GetComponent<T>();

            if (component is IInitialize obj)
                obj.Initialize();

            return component;
        }
    }
}