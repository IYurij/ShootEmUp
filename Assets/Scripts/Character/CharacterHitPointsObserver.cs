using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterHitPointsObserver : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private GameManager _gameManager;
        
        private void OnEnable()
        {
            _character.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            if (_character != null)
                _character.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();
    }
}