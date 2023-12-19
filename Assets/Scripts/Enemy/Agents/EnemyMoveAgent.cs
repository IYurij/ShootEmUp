using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, IGameFixedUpdateListener
    {
        public bool IsReached
        {
            get { return _isReached; }
        }

        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private float _moveThreshold = 0.25f;

        private Vector2 _destination;
        private bool _isReached;

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isReached = false;
        }

        public void OnFixedUpdate(float fixedTimeDelta)
        {
            if (_isReached)
            {
                return;
            }
            
            var vector = _destination - (Vector2)transform.position;
            if (vector.sqrMagnitude <= _moveThreshold * _moveThreshold)
            {
                _isReached = true;
                return;
            }

            var direction = vector.normalized * fixedTimeDelta;
            _moveComponent.Move(direction);
        }
    }
}