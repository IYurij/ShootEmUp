using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class FireInput : MonoBehaviour, IGameUpdateListener
    {
        public bool FireRequired { get; private set; }

        public void OnUpdate(float deltaTime)
        {
            FireRequired = Input.GetKeyDown(KeyCode.Space);
        }
    }
}