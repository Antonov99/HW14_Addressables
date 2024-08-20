using UnityEngine;
using Zenject;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "ProjectInstaller",
        menuName = "Installers/New ProjectInstaller"
    )]
    public sealed class ProjectInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ApplicationExiter>().AsSingle().NonLazy();
            Container.Bind<GameLoader>().AsSingle().NonLazy();
            Container.Bind<MenuLoader>().AsSingle().NonLazy();
            Container.Bind<LocalAssetLoader>().AsSingle().NonLazy();
            Container.Bind<AddressablesAssetFactory>().AsSingle().NonLazy();
            Container.Bind<LocationSpawnManager>().AsSingle().NonLazy();
        }
    }
}