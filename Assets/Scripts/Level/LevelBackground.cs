using System;
using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private Params m_params;

        private Transform _myTransform;
        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;

        private void Awake()
        {
            _startPositionY = m_params.m_startPositionY;
            _endPositionY = m_params.m_endPositionY;
            _movingSpeedY = m_params.m_movingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
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

        [Serializable]
        public sealed class Params
        {
            [SerializeField] public float m_startPositionY;

            [SerializeField] public float m_endPositionY;

            [SerializeField] public float m_movingSpeedY;
        }
    }
}