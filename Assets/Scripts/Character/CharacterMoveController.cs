using UnityEngine;
using VContainer;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour, IGameFixedUpdateListener
    {
        private MoveInput _moveInput;
        private GameObject _character;

        [Inject]
        private void Construct(GameObject character, MoveInput moveInput)
        {
            _character = character;
            _moveInput = moveInput;
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            _character.GetComponent<MoveComponent>()
                      .Move(new Vector2(_moveInput.Horizontal, 0) * Time.fixedDeltaTime);
        }
    }
}
