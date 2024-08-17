using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class MenuScreen : MonoBehaviour,IInitialize
    {
        [SerializeField]
        private Button startButton;

        [SerializeField]
        private Button exitButton;
        
        private ApplicationExiter _applicationExiter;
        private GameLoader _gameLoader;
        
        [Inject]
        public void Construct(ApplicationExiter applicationFinisher, GameLoader gameLoader)
        {
            _applicationExiter = applicationFinisher;
            _gameLoader = gameLoader;
        }

        public void Initialize()
        {
            startButton.onClick.AddListener(_gameLoader.LoadGame);
            exitButton.onClick.AddListener(_applicationExiter.ExitApp);
        }

        private void OnDisable()
        {
            startButton.onClick.RemoveListener(_gameLoader.LoadGame);
            exitButton.onClick.RemoveListener(_applicationExiter.ExitApp);
        }
    }
}