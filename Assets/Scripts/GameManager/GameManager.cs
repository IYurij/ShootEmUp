using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class GameManager : ITickable, IFixedTickable
    {
        private readonly List<IGameListener> _listeners = new();
        private readonly List<IGameUpdateListener> _updateListeners = new();
        private readonly List<IGameFixedUpdateListener> _fixedUpdateListeners = new();

        private GameState _gameState = GameState.OFF;

        public void FixedTick()
        {
            if (_gameState != GameState.PLAYING)
            {
                return;
            }
             
            for (var i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                _fixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }

        public void Tick()
        {
            if (_gameState != GameState.PLAYING) 
            {
                return;
            }

            for (var i = 0; i < _updateListeners.Count; i++)
            {
                _updateListeners[i].OnUpdate(Time.deltaTime);
            }
        }

        public void AddListeners(IGameListener[] gameListeners)
        {
            for (int i = 0; i < gameListeners.Length; i++)
            {
                AddListener(gameListeners[i]);
            }
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

        public void RemoveListeners(IGameListener[] gameListeners)
        {
            for (int i = 0; i < gameListeners.Length; i++)
            {
                RemoveListener(gameListeners[i]);
            }
        }

        public void RemoveListener(IGameListener gameListener)
        {
            _listeners.Add(gameListener);

            if (gameListener is IGameUpdateListener gameUpdateListener)
            {
                _updateListeners.Remove(gameUpdateListener);
            }

            if (gameListener is IGameFixedUpdateListener gameFixedUpdateListener)
            {
                _fixedUpdateListeners.Remove(gameFixedUpdateListener);
            }
        }

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            if (_gameState != GameState.OFF)
            {
                Debug.LogWarning($"You can start game only from {GameState.OFF} state!");
                return;
            }

            foreach (var gameListener in _listeners)
            {
                if(gameListener is IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }

            _gameState = GameState.PLAYING;
        }

        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            if (_gameState is not GameState.PLAYING or GameState.OFF)
            {
                Debug.LogWarning($"You can finish game only from {GameState.PLAYING} or {GameState.OFF} state!");
                return;
            }

            foreach (var gameListener in _listeners)
            {
                if (gameListener is IGameFinishListener finishListener)
                {
                    finishListener.OnFinish();
                }
            }

            _gameState = GameState.FINISH;

            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

        [ContextMenu("Pause Game")]
        public void PauseGame()
        {
            if (_gameState != GameState.PLAYING)
            {
                Debug.LogWarning($"You can pause game only from {GameState.PLAYING} state!");
                return;
            }

            foreach (var gameListener in _listeners)
            {
                if (gameListener is IGamePauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }

            _gameState= GameState.PAUSE;
        }

        [ContextMenu("Resume Game")]
        public void ResumeGame()
        {
            if (_gameState != GameState.PAUSE)
            {
                Debug.LogWarning($"You can resume game only from {GameState.PAUSE} state!");
                return;
            }

            foreach (var gameListener in _listeners)
            {
                if (gameListener is IGameResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }

            _gameState = GameState.PLAYING;
        }
    }
}