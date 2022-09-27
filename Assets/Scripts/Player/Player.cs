using System;
using ColorSystem;
using Gameplay;
using Obstacles;
using Player.Movement;
using Player.Visual;
using Sound;
using UnityEngine;
using Zenject;

namespace Player
{
    [Serializable]
    public class PlayerAnimationData
    {
        [SerializeField] private string victoryParameter = "Victory";
        [SerializeField] private string defeatParameter = "Defeat";
        
        public int VictoryParameter { get; private set; }
        public int DefeatParameter { get; private set; }

        public void Initialize()
        {
            VictoryParameter = Animator.StringToHash(victoryParameter);
            DefeatParameter = Animator.StringToHash(defeatParameter);
        }
    }
    
    
    public class Player : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerMovement movement;
        [SerializeField] private PlayerScaler scaler;
        [SerializeField] private PlayerVisual visual;
        [SerializeField] private SoundObserver tickSound;
        
        [Header("Parameters")] 
        [SerializeField] private PlayerParametersData parametersData;
        [SerializeField] private PlayerAnimationData animationData;
        

        private Color _color;
        private GameState _gameState;
        
        [Inject]
        private void Construct(GameState state)
        {
            _gameState = state;
            _gameState.OnGameStart += StartGame;
            _gameState.OnGameOver += Defeat;
        }

        private void Start()
        {
            animationData.Initialize();
            scaler.Initialize(parametersData.SizeDelta);
        }

        private void StartGame()
        {
            movement.Enable();
        }

        private void Defeat()
        {
            movement.Disable();
            animator.SetTrigger(animationData.DefeatParameter);
        }

        private void Victory()
        {
            movement.Disable();
            animator.SetTrigger(animationData.VictoryParameter);
            _gameState.Victory();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out DecorateZone zone))
            {
                DecoratePlayer(zone);   
            }

            if (other.TryGetComponent(out Obstacle obstacle))
            {
                ObstacleCollision(obstacle);
            }

            if (other.TryGetComponent(out VictoryCollider victoryCollider))
            {
                Victory();
            }
        }

        private void DecoratePlayer(DecorateZone zone)
        {
            _color = zone.Color.correct;
            visual.ChangeColor(_color);
        }

        private void ObstacleCollision(Obstacle obstacle)
        {
            if (obstacle.Color == _color)
            {
                _gameState.AddScorePoints();
                visual.Tick();
                tickSound.Play();
            }
            else
            {
                _gameState.SubtractScorePoints();
            }
            scaler.UpdateScale(_gameState.Score);
            obstacle.Delete();
        }
    }
}