﻿using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCouldownSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private float delay = 1;

        private float timer;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                _enemyManager.SetEnemy();
                timer -= delay;
            }
        }
    }
}