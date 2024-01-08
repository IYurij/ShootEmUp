using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public class CharacterMoveController : IGameFixedUpdateListener
    {
        private readonly MoveInput _moveInput;
        private readonly GameObject _character;
        
        public CharacterMoveController(GameObject character, MoveInput moveInput)
        {
            _character = character;
            _moveInput = moveInput;
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            _character.GetComponent<MoveComponent>()
                      .Move(new Vector2(_moveInput.Horizontal, 0) * fixedDeltaTime);
        }
    }
}
