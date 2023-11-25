using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private GameObject target;
        [SerializeField] private EnemyPool enemyPool;
        
        public GameObject TrySpawnEnemy()
        {
            var enemy = enemyPool.TryRemove();

            if (!enemy)
            {
                return null;
            }

            return SpawnEnemy(enemy);
        }

        private GameObject SpawnEnemy(GameObject enemy)
        {
            var spawnPosition = this.enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = this.enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().SetTarget(this.target);
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemyPool.Add(enemy);
        }
    }
}
