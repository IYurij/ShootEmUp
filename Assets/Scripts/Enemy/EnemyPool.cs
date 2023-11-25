using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [SerializeField] private GameObject _target;

        [Header("Pool")]
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _enemiesCount = 6;

        private readonly Queue<GameObject> _enemyPool = new();

        private void Awake()
        {
            for (var i = 0; i < _enemiesCount; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                enemy.GetComponent<EnemyAttackAgent>().SetTarget(_target);
                this.Add(enemy);
            }
        }

        public void Add(GameObject enemy)
        {
            _enemyPool.Enqueue(enemy);
        }

        public GameObject TryRemove()
        {
            if (!_enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            return enemy;
        }
    }
}