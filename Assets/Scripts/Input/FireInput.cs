using UnityEngine;

namespace ShootEmUp
{
    public sealed class FireInput : MonoBehaviour
    {
        public bool FireRequired { get; private set; }

        private void Update()
        {
            FireRequired = Input.GetKeyDown(KeyCode.Space);
        }
    }
}