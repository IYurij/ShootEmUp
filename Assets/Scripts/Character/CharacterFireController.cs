using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class CharacterFireController :
        IGameStartListener, 
        IGamePauseListener, 
        IGameResumeListener,
        IGameFinishListener
    {
        private readonly FireInput _fireInput;
        private readonly GameObject _character;
        private readonly BulletSystem _bulletSystem;
        private readonly BulletConfig _bulletConfig;

        public CharacterFireController(GameObject character,
            FireInput fireInput,
            BulletSystem bulletSystem,
            BulletConfig bulletConfig)
        {
            _character = character;
            _fireInput = fireInput;
            _bulletSystem = bulletSystem;
            _bulletConfig = bulletConfig;
        }

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