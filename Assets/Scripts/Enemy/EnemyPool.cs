using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _enemiesCount = 6;

        public int EnemiesCount => _enemiesCount;

        private readonly Queue<GameObject> _enemyPool = new();

        private void Awake()
        {
            for (var i = 0; i < _enemiesCount; i++)
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

        private GameObject Add()
        {
            var enemy = Instantiate(_prefab, _container);
            enemy.SetActive(false);

            return enemy;
        }
    }
}