using UnityEngine;
using Zenject;
using Helper;
namespace Config{
    public class ConfigInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IConfig>().To<TrainingConfig>().AsSingle().NonLazy();
            Container.Bind<IRewardHandler>().To<RewardHandler>().AsSingle().NonLazy();
        }
    }
}