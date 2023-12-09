using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class EnemyCouldownSpawner : MonoBehaviour, IGameUpdateListener
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private float delay = 1;

        private float timer;

        public void OnUpdate(float deltaTime)
        {
            timer += deltaTime;
            if (timer > delay)
            {
                _enemyManager.SetEnemy();
                timer -= delay;
            }
        }
    }
}