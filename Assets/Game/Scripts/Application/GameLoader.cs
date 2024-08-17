using JetBrains.Annotations;
using UnityEngine.AddressableAssets;
namespace SampleGame
{
    [UsedImplicitly]
    public sealed class GameLoader
    {
        public void LoadGame()
        {
            Addressables.LoadSceneAsync("Game");
        }
    }
}