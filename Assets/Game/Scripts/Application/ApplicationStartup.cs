using Game.Scripts;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    public class ApplicationStartup : MonoBehaviour
    {
        [SerializeField]
        private Transform parent;

        private LocalAssetLoader _localAssetLoader;
        private Factory _factory;

        private const string _MENU_ID = "MenuScreen";
        private const string _PAUSE_ID = "PauseScreen";

        [Inject]
        public void Construct(LocalAssetLoader localAssetLoader, Factory factory)
        {
            _localAssetLoader = localAssetLoader;
            _factory = factory;
        }

        private async void Start()
        {
            await _localAssetLoader.Load<GameObject>(_MENU_ID);
            await _localAssetLoader.Load<GameObject>(_PAUSE_ID);
            
            _factory.InstantiateObject<MenuScreen>(_MENU_ID, parent);
        }
    }
}