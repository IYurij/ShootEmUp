using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private BulletSystem _bulletSystem;
        
        private readonly HashSet<GameObject> m_activeEnemies = new();

        private void Update()
        {
            Invoke(nameof(SetEnemy), 1);
        }

        private void SetEnemy()
        {
            var enemy = _enemySpawner.TrySpawnEnemy();
            if (enemy != null)
            {
                if (m_activeEnemies.Add(enemy))
                {
                    enemy.GetComponent<HitPointsComponent>().hpEmpty += OnDestroyed;
                    enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().hpEmpty -= OnDestroyed;
                enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

                _enemySpawner.UnspawnEnemy(enemy);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int) PhysicsLayer.ENEMY_BULLET,
                color = Color.red,
                damage = 1,
                position = position,
                velocity = direction * 2.0f
            });
        }
    }
}