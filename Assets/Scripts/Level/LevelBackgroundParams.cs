using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class LevelBackgroundParams
    {
        public float _startPositionY = 19;

        public float _endPositionY = -38;

        public float _movingSpeedY = 5;
    }
}