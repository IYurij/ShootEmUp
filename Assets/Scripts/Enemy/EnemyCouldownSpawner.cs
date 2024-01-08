using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class EnemyCouldownSpawner : IGameUpdateListener
    {
        private readonly EnemyManager _enemyManager;
        private readonly float _delay = 1;
        private float _timer;

        public EnemyCouldownSpawner(EnemyManager enemyManager)
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