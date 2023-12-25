using UnityEngine;
using VContainer;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class CharacterFireController : MonoBehaviour,
        IGameStartListener, 
        IGamePauseListener, 
        IGameResumeListener,
        IGameFinishListener
    {
        private FireInput _fireInput;
        private GameObject _character;
        private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;

        [Inject]
        private void Construct(GameObject character,
            FireInput fireInput,
            BulletSystem bulletSystem)
            //BulletConfig bulletConfig)
        {
            _character = character;
            _fireInput = fireInput;
            _bulletSystem = bulletSystem;
            //_bulletConfig = bulletConfig;
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