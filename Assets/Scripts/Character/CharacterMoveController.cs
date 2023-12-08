using ShootEmUp;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    [SerializeField] private MoveInput _moveInput;
    [SerializeField] private GameObject _character;

    private void FixedUpdate()
    {
        _character.GetComponent<MoveComponent>()
                  .Move(new Vector2(_moveInput.HorizontalDirection, 0) * Time.fixedDeltaTime);
    }
}
