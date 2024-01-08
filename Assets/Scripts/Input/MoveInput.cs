using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class MoveInput : IGameUpdateListener
    {
        public float Horizontal { get; private set; }

        public void OnUpdate(float deltaTime)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
        } 
    }
}