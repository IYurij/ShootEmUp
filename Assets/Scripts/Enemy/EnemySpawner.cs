using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _target;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private BulletSystem _bulletSystem;

        public GameObject SpawnEnemy()
        {
            var enemy = _enemyPool.Get();

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().Setup(_target, _bulletSystem);

            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            _enemyPool.Release(enemy);
        }
    }
}
