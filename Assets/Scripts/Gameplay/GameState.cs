using System;
using Input;
using MapGeneration;
using UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Zenject;

namespace Gameplay
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private int maxScore = 10;
        [SerializeField] private Fader fader;
        [SerializeField] private MapGenerator generator;
        
        [SerializeField] private UnityEvent onGameStart;
        [SerializeField] private UnityEvent onVictory;
        [SerializeField] private UnityEvent onGameOver;
        
        private int _currentScore;
        private ScoreCounter _counter;
        private IPlayerInput _input;

        public int Score => _currentScore;
        
        public event UnityAction OnGameStart
        {
            add => onGameStart.AddListener(value);
            remove => onGameStart.RemoveListener(value);
        }
        
        public event UnityAction OnVictory
        {
            add => onVictory.AddListener(value);
            remove => onVictory.RemoveListener(value);
        }
        
        public event UnityAction OnGameOver
        {
            add => onGameOver.AddListener(value);
            remove => onGameOver.RemoveListener(value);
        }

        [Inject]
        private void Construct(ScoreCounter counter, IPlayerInput input)
        {
            _counter = counter;
            _input = input;
        }


        private async void Start()
        {
            await generator.Generate();
            fader.FadeOut();
            _input.Actions.Player.Move.started += StartGame;

        }

        private void StartGame(InputAction.CallbackContext obj)
        {
            onGameStart?.Invoke();
            _input.Actions.Player.Move.started -= StartGame;
        }

        public void AddScorePoints()
        {
            _currentScore++;
            _currentScore = Mathf.Clamp(_currentScore, 0, maxScore);
            _counter.UpdatePoints(_currentScore);
        }

        public void SubtractScorePoints()
        {
            _currentScore--;
            if(CheckGameState());
                _counter.UpdatePoints(_currentScore);
        }

        private bool CheckGameState()
        {
            if(_currentScore < 0) GameOver();
            return _currentScore > 0;
        }

        private void GameOver()
        {
            onGameOver?.Invoke();
        }
    }
}