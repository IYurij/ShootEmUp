using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class MoveInput : MonoBehaviour, IGameUpdateListener
    {
        public float Horizontal { get; private set; }

        public void OnUpdate(float deltaTime)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
        } 
    }
}