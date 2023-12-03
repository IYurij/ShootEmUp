using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private int _enemiesCount = 6;

        private readonly HashSet<GameObject> m_activeEnemies = new();

        private void Awake()
        {
            _enemyPool.InitPool(_enemiesCount);
        }

        public void SetEnemy()
        {
            if (m_activeEnemies.Count < _enemiesCount)
            {
                var enemy = _enemySpawner.SpawnEnemy();

                if (m_activeEnemies.Add(enemy))
                {
                    enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            DestroyEnemy(enemy);
        }

        private void DestroyEnemy(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;

                _enemySpawner.UnspawnEnemy(enemy);
            }
        }
    }
}