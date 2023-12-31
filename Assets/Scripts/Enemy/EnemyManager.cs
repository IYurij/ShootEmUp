using System.Collections.Generic;
using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class EnemyManager
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly EnemyPool _enemyPool;
        private readonly GameManager _gameManager;
        
        private readonly HashSet<GameObject> _activeEnemies = new();
        
        public EnemyManager(GameManager gameManager, EnemyPool enemyPool, EnemySpawner enemySpawner)
        {
            _gameManager = gameManager;
            _enemyPool = enemyPool;
            _enemySpawner = enemySpawner;
        }

        public void SpawnEnemy()
        {
            if (_activeEnemies.Count < _enemyPool.EnemiesCount)
            {
                var enemy = _enemySpawner.SpawnEnemy();

                if (_activeEnemies.Add(enemy))
                {
                    enemy.SetActive(true);
                    enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;
                    _gameManager.AddListeners(enemy.GetComponentsInChildren<IGameListener>(true));
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            DestroyEnemy(enemy);
        }

        private void DestroyEnemy(GameObject enemy)
        {
            if (_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;
                _gameManager.RemoveListeners(enemy.GetComponentsInChildren<IGameListener>());
                _enemySpawner.UnspawnEnemy(enemy);
            }
        }
    }
}