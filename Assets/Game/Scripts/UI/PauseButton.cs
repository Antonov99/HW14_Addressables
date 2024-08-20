using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class PauseButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [SerializeField]
        private Transform parent;

        private AddressablesAssetFactory _addressablesAssetFactory;

        private PauseScreen _pauseScreen;

        private const string _PAUSE_ID = "PauseScreen";

        [Inject]
        public void Construct(AddressablesAssetFactory addressablesAssetFactory)
        {
            _addressablesAssetFactory = addressablesAssetFactory;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(Show);
            _pauseScreen = _addressablesAssetFactory.InstantiateObject<PauseScreen>(_PAUSE_ID, parent);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Show);
        }

        private void Show()
        {
            _pauseScreen.Show();
        }
    }
}