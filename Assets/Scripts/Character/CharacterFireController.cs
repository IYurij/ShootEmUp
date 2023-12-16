using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class CharacterFireController : MonoBehaviour, 
        IGameStartListener, 
        IGamePauseListener, 
        IGameResumeListener,
        IGameFinishListener
    {
        [SerializeField] private FireInput _fireInput;
        [SerializeField] private GameObject _character;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        public void OnStart()
        {
            _fireInput.OnFire += Fire;
        }

        public void OnPause()
        {
            _fireInput.OnFire -= Fire;
        }

        public void OnResume()
        {
            _fireInput.OnFire += Fire;
        }

        public void OnFinish()
        {
            _fireInput.OnFire -= Fire;
        }

        private void Fire()
        {
            var weapon = _character.GetComponent<WeaponComponent>();

            _bulletSystem.SpawnBullet(new BulletArgs
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