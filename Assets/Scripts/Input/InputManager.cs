using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private CharacterController _characterController;

        public float HorizontalDirection { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _characterController._fireRequired = true;
            }

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
        
        private void FixedUpdate()
        {
            _character.GetComponent<MoveComponent>()
                      .MoveByRigidbodyVelocity(new Vector2(HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}