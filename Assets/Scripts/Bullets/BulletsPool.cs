using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public class BulletsPool : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private int _initialCount = 50;

        private IObjectResolver _resolver;
        private readonly Queue<Bullet> _bulletPool = new();

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public void Initialize()
        {
            for (var i = 0; i < _initialCount; i++)
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
            Bullet bullet = _resolver.Instantiate(_prefab, _container);
            bullet.gameObject.SetActive(true);

            return bullet;
        }
    }
}
