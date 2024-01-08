using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class CharacterHitPointsObserver :
        IGameStartListener,
        IGameFinishListener
    {
        private readonly GameObject _character;
        private readonly GameManager _gameManager;
 
        public CharacterHitPointsObserver(GameObject character, GameManager gameManager)
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