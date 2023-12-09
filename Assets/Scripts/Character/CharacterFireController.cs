using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class CharacterFireController : MonoBehaviour, IGameFixedUpdateListener 
    {
        [SerializeField] private FireInput _fireInput;
        [SerializeField] private GameObject _character;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (_fireInput.FireRequired)
            {
                OnFlyBullet();
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