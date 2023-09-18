using UnityEngine;
using Zenject;

namespace Config{
    public class ConfigInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IConfig>().To<TrainingConfig>().AsSingle().NonLazy();
        }
    }
}