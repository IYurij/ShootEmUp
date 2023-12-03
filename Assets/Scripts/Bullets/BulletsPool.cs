using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletsPool : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Bullet _prefab;

        private readonly Queue<Bullet> _bulletPool = new(); 

        public void InitPool(int initialCount)
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Add();
                _bulletPool.Enqueue(bullet);
            }
        }

        public Bullet Get()
        {
            if (_bulletPool.TryDequeue(out var bullet))
            {
                return bullet;
            }

            return Add();
        }

        public void Release(Bullet bullet)
        {
            _bulletPool.Enqueue(bullet);
            bullet.gameObject.SetActive(false);
        }

        private Bullet Add()
        {
            Bullet bullet = Instantiate(_prefab, _container);
            bullet.gameObject.SetActive(true);

            return bullet;
        }
    }
}
