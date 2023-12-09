using System.Collections.Generic;
using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletsPool _bulletsPool;

        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            m_cache.Clear();
            m_cache.AddRange(m_activeBullets);

            for (int i = 0, count = m_cache.Count; i < count; i++)
            {
                var bullet = m_cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void SpawnBullet(Args args)
        {
            Bullet bullet = _bulletsPool.Get();

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet._damage = args.damage;
            bullet._isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);
            
            if (m_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (m_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                _bulletsPool.Release(bullet);
            }
        }

        public class Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}