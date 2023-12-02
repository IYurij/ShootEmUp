using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterFireController : MonoBehaviour 
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        public bool _fireRequired;

        private void FixedUpdate()
        {
            if (_fireRequired)
            {
                OnFlyBullet();
                _fireRequired = false;
            }
        }

        private void OnFlyBullet()
        {
            var weapon = _character.GetComponent<WeaponComponent>();

            _bulletSystem.SpawnBullet(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int) _bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * _bulletConfig.speed
            });
        }
    }
}