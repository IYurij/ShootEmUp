using System;
using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class FireInput : MonoBehaviour, IGameUpdateListener
    {
        public event Action OnFire;

        public void OnUpdate(float deltaTime)
        {
            if(Input.GetKeyDown(KeyCode.Space))
                OnFire?.Invoke();
        }
    }
}