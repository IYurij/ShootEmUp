using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _weaponComponent;
        [SerializeField] private EnemyMoveAgent _moveAgent;
        [SerializeField] private float _countdown;

        public delegate void FireHandler(GameObject enemy, Vector2 position, Vector2 direction);

        private BulletSystem _bulletSystem;
        private GameObject _target;
        private float _currentTime;

        public void Setup(GameObject target, BulletSystem bulletSystem)
        {
            _target = target;
            _bulletSystem = bulletSystem;
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        private void FixedUpdate()
        {
            if (!_moveAgent.IsReached)
            {
                return;
            }
            
            if (!_target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _countdown;
            }
        }

        private void Fire()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2) _target.transform.position - startPosition;
            var direction = vector.normalized;
            OnFire(startPosition, direction);
        }

        private void OnFire(Vector2 position, Vector2 direction)
        {
            _bulletSystem.SpawnBullet(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)PhysicsLayer.ENEMY_BULLET,
                color = Color.red,
                damage = 1,
                position = position,
                velocity = direction * 2.0f
            });
        }
    }
}