using Zenject;
using UnityEngine;

namespace Framework.FSM.MainMenu
{
    public class MainMenuFSMInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuFSM m_mainMenuFSM;

        public override void InstallBindings()
        {
            Container.Bind<MainMenuFSM>().FromInstance(m_mainMenuFSM).AsSingle().NonLazy();
            Container.QueueForInject(m_mainMenuFSM);
        }
    }
}
