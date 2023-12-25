using UnityEngine;
using VContainer;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class EnemyCouldownSpawner : MonoBehaviour,
        IGameUpdateListener
    {
        private EnemyManager _enemyManager;
        [SerializeField] private float _delay = 1;

        private float _timer;

        [Inject]
        private void Construct(EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
        }

        public void OnUpdate(float deltaTime)
        {
            _timer += deltaTime;
            if (_timer > _delay)
            {
                _enemyManager.SpawnEnemy();
                _timer -= _delay;
            }
        }
    }
}