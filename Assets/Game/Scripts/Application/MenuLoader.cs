using JetBrains.Annotations;
using UnityEngine.AddressableAssets;
using Zenject;

namespace SampleGame
{
    [UsedImplicitly]
    public sealed class MenuLoader
    {
        private LocationSpawnManager _locationSpawnManager;

        [Inject]
        public void Construct(LocationSpawnManager locationSpawnManager)
        {
            _locationSpawnManager = locationSpawnManager;
        }

        public void LoadMenu()
        {
            _locationSpawnManager.UnloadLocation();
            Addressables.LoadSceneAsync("Menu");
        }
    }
}