using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _enemiesCount = 6;
        private IObjectResolver _resolver;

        public int EnemiesCount => _enemiesCount;

        private readonly Queue<GameObject> _enemyPool = new();

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
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
            var enemy = _resolver.Instantiate(_prefab, _container);
            enemy.SetActive(false);

            return enemy;
        }
    }
}