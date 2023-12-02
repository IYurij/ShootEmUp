using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        
        private readonly HashSet<GameObject> m_activeEnemies = new();

        public void SetEnemy()
        {
            var enemy = _enemySpawner.TrySpawnEnemy();
            if (enemy != null)
            {
                if (m_activeEnemies.Add(enemy))
                {
                    enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnDestroyed;
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnDestroyed;

                _enemySpawner.UnspawnEnemy(enemy);
            }
        }
    }
}