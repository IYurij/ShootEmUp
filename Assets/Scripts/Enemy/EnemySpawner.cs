using UnityEngine;
using VContainer;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyPositions _enemyPositions;
        private GameObject _target;
        private EnemyPool _enemyPool;

        [Inject]
        private void Construct(GameObject target, EnemyPool enemyPool)
        {
            _target = target;
            _enemyPool = enemyPool;
        }

        public GameObject SpawnEnemy()
        {
            var enemy = _enemyPool.Get();

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            var attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);

            enemy.GetComponent<EnemyAttackAgent>().Setup(_target);

            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            _enemyPool.Release(enemy);
        }
    }
}
