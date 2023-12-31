using System;
using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour,
        IGamePauseListener,
        IGameResumeListener
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [NonSerialized] public bool _isPlayer;
        [NonSerialized] public int _damage;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private Vector3 _pausedVelocity;
        private float _pausedAngularVelocity;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
            DealDamage(collision.gameObject);
        }

        public void OnPause()
        {
            _pausedAngularVelocity = _rigidbody2D.angularVelocity;
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        public void OnResume()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody2D.velocity = _pausedVelocity;
            _rigidbody2D.angularVelocity = _pausedAngularVelocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rigidbody2D.velocity = velocity;
            _pausedVelocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        private void DealDamage(GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (_isPlayer == team.IsPlayer)
            {
                return;
            }
            
            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                
                hitPoints.TakeDamage(_damage);
            }
        }
    }
}