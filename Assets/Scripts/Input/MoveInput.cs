using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class MoveInput : MonoBehaviour, IGameUpdateListener
    {
        public float HorizontalDirection { get; private set; }

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                HorizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                HorizontalDirection = 1;
            }
            else
            {
                HorizontalDirection = 0;
            }
        } 
    }
}