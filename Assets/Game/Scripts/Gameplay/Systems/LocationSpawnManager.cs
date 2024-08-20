using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    [UsedImplicitly]
    public sealed class LocationSpawnManager
    {
        private LocalAssetLoader _loader;
        private AddressablesAssetFactory _factory;

        private readonly List<string> _locationID = new();

        [Inject]
        public void Construct(LocalAssetLoader loader, AddressablesAssetFactory factory)
        {
            _loader = loader;
            _factory = factory;
        }

        public async void LoadLocation(string id, Transform transform)
        {
            if (_locationID.Contains(id)) return;

            await _loader.Load<GameObject>(id);
            _factory.InstantiateObject<GameObject>(id, transform);

            _locationID.Add(id);
        }

        public void UnloadLocation()
        {
            _locationID.Clear();
        }
    }
}