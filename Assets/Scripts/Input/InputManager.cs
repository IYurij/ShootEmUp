using ShootEmUp;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private FireInput _fireInput;
    [SerializeField] private MoveInput _moveInput;
    [SerializeField] private CharacterFireController _characterFireController;

    private void Update()
    {
        _moveInput.Move();
        _fireInput.Fire(_characterFireController);
    }

    private void FixedUpdate()
    {
        _moveInput.UpdatePosition(_character);
    }
}
