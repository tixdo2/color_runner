using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private ScoreCounter counter;

        public override void InstallBindings()
        {
            Container.Bind<ScoreCounter>().FromInstance(counter).AsSingle();
        }
    }
}