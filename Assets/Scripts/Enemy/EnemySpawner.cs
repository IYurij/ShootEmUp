using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _target;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletSystem _bulletSystem;
        
        public GameObject TrySpawnEnemy()
        {
            var enemy = _enemyPool.TryRemove();

            if (!enemy)
            {
                return null;
            }

            return SpawnEnemy(enemy);
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.SetActive(false);
            _enemyPool.Add(enemy);
        }

        private GameObject SpawnEnemy(GameObject enemy)
        {
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().Setup(_target, _bulletSystem);

            enemy.SetActive(true);

            return enemy;
        }
    }
}
