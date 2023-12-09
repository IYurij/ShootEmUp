using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public enum GameState
    {
        None,
        Start,
        Finish,
        Pause,
        Resume
    }

    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField, ReadOnly] private GameState _gameState;
        private readonly List<IGameListener> _listeners = new();
        private readonly List<IGameUpdateListener> _updateListeners = new();
        private readonly List<IGameFixedUpdateListener> _fixedUpdateListeners = new();

        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

        public void AddListener(IGameListener gameListener)
        {
            _listeners.Add(gameListener);

            if (gameListener is IGameUpdateListener gameUpdateListener)
            {
                _updateListeners.Add(gameUpdateListener);
            }

            if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
            {
                _fixedUpdateListeners.Add(gameFixedUpdateListener);
            }
        }

        private void Update()
        {
            for (var i = 0; i < _updateListeners.Count;i++)
            {
                _updateListeners[i].OnUpdate(Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            for (var i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                _fixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }

        private void Start()
        {
            foreach (var gameListener in _listeners)
            {
                if(gameListener is IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }

            _gameState = GameState.Start;
        }

        private void Finish()
        {
            foreach (var gameListener in _listeners)
            {
                if (gameListener is IGameFinishListener finishListener)
                {
                    finishListener.OnFinish();
                }
            }

            _gameState = GameState.Finish;
        }

        private void Pause()
        {
            foreach (var gameListener in _listeners)
            {
                if (gameListener is IGamePauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }

            _gameState= GameState.Pause;
        }

        private void Resume()
        {
            foreach (var gameListener in _listeners)
            {
                if (gameListener is IGameResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }

            _gameState = GameState.Resume;
        }
    }
}