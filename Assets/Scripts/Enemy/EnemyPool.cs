using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;

        private readonly Queue<GameObject> _enemyPool = new();

        public void InitPool(int enemiesCount)
        {
            for (var i = 0; i < enemiesCount; i++)
            {
                var enemy = Add();
                _enemyPool.Enqueue(enemy);
            }
        }

        public GameObject Get()
        {
            if (_enemyPool.TryDequeue(out var enemy))
            {
                return enemy;
            }

            return Add();
        }

        public void Release(GameObject enemy)
        {
            _enemyPool.Enqueue(enemy);
            enemy.SetActive(false);
        }

        public GameObject Add()
        {
            var enemy = Instantiate(_prefab, _container);
            enemy.SetActive(false);

            return enemy;
        }
    }
}