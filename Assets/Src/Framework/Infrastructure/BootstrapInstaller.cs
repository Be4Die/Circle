using Zenject;
using UnityEngine;
using Framework.EffectSystem;

namespace Framework.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private EffectSystemConfig m_effectSystemConfig;
        public override void InstallBindings()
        {
            Container.Bind<EffectSystemConfig>().FromInstance(m_effectSystemConfig).AsSingle().NonLazy();
            Container.QueueForInject(m_effectSystemConfig);
        }
    }
}
