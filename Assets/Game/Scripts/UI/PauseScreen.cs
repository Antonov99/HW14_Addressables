using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class PauseScreen : MonoBehaviour, IInitialize
    {
        [SerializeField]
        private Button resumeButton;

        [SerializeField]
        private Button exitButton;

        private MenuLoader _menuLoader;

        [Inject]
        public void Construct(MenuLoader menuLoader)
        {
            _menuLoader = menuLoader;
        }

        public void Initialize()
        {
            Hide();
            resumeButton.onClick.AddListener(Hide);
            exitButton.onClick.AddListener(_menuLoader.LoadMenu);
        }

        private void OnDestroy()
        {
            resumeButton.onClick.RemoveListener(Hide);
            exitButton.onClick.RemoveListener(_menuLoader.LoadMenu);
        }

        public void Show()
        {
            Time.timeScale = 0; //KISS
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            Time.timeScale = 1; //KISS
            gameObject.SetActive(false);
        }
    }
}