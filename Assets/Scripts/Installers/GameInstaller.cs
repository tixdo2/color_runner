using Gameplay;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameState gameState;
        
        public override void InstallBindings()
        {
            Container.Bind<GameState>().FromInstance(gameState).AsSingle();
        }
    }
}