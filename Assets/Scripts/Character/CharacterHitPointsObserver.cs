using UnityEngine;
using VContainer;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class CharacterHitPointsObserver : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        private GameObject _character;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameObject character, GameManager gameManager)
        {
            _character = character;
            _gameManager = gameManager;
        }

        public void OnStart()
        {
            _character.GetComponent<HitPointsComponent>().OnHitPointsEmpty += OnCharacterDeath;
        }

        public void OnFinish()
        {
            if (_character != null)
                _character.GetComponent<HitPointsComponent>().OnHitPointsEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => _gameManager.FinishGame();
    }
}