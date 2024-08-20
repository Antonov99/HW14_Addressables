
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class ApplicationStartup : MonoBehaviour
    {
        [SerializeField]
        private Transform parent;

        private LocalAssetLoader _localAssetLoader;
        private AddressablesAssetFactory _addressablesAssetFactory;

        private const string _MENU_ID = "MenuScreen";
        private const string _PAUSE_ID = "PauseScreen";

        [Inject]
        public void Construct(LocalAssetLoader localAssetLoader, AddressablesAssetFactory addressablesAssetFactory)
        {
            _localAssetLoader = localAssetLoader;
            _addressablesAssetFactory = addressablesAssetFactory;
        }

        private async void Start()
        {
            await _localAssetLoader.Load<GameObject>(_MENU_ID);
            await _localAssetLoader.Load<GameObject>(_PAUSE_ID);
            
            _addressablesAssetFactory.InstantiateObject<MenuScreen>(_MENU_ID, parent);
        }
    }
}