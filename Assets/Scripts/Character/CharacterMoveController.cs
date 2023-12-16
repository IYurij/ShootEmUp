using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public class CharacterMoveController : MonoBehaviour, IGameFixedUpdateListener
    {
        [SerializeField] private MoveInput _moveInput;
        [SerializeField] private GameObject _character;

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            _character.GetComponent<MoveComponent>()
                      .Move(new Vector2(_moveInput.Horizontal, 0) * Time.fixedDeltaTime);
        }
    }
}
