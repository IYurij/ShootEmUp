using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class EnemyCouldownSpawner : MonoBehaviour
        , IGameUpdateListener
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private float _delay = 1;

        private float _timer;

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