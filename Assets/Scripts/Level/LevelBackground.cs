using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour,
        IGameFixedUpdateListener
    {
        [SerializeField] private LevelBackgroundParams _levelBackGroundParams;
        [SerializeField] private GameManager _gameManager;

        private Transform _myTransform;
        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;

        private void Awake()
        {
            _startPositionY = _levelBackGroundParams._startPositionY;
            _endPositionY = _levelBackGroundParams._endPositionY;
            _movingSpeedY = _levelBackGroundParams._movingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;

            _gameManager.AddListener(GetComponent<IGameListener>());
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * fixedDeltaTime,
                _positionZ
            );
        }
    }
}