using Input;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private InputSystem inputSystem;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerInput>().FromInstance(inputSystem).AsSingle();
        }
    }
}