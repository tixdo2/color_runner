using Gameplay;
using Sound;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameState gameState;
        [SerializeField] private SoundHandler soundHandler;
        
        
        public override void InstallBindings()
        {
            Container.Bind<GameState>().FromInstance(gameState).AsSingle();
            Container.Bind<ISoundHandler>().FromInstance(soundHandler).AsSingle();
        }
    }
}