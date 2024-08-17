using JetBrains.Annotations;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
    [UsedImplicitly]
    public sealed class MenuLoader
    {
        public void LoadMenu()
        {
            Addressables.LoadSceneAsync("Menu");
        }
    }
}