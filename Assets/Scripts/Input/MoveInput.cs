using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveInput : MonoBehaviour
    {
        private float _horizontalDirection;

        public void Move()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _horizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                _horizontalDirection = 1;
            }
            else
            {
                _horizontalDirection = 0;
            }
        }

        public void UpdatePosition(GameObject _character)
        {
            _character.GetComponent<MoveComponent>()
                      .Move(new Vector2(_horizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}