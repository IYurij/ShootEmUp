using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class LevelBackgroundParams
    {
        [SerializeField] public float _startPositionY = 19;

        [SerializeField] public float _endPositionY = -38;

        [SerializeField] public float _movingSpeedY = 5;
    }
}