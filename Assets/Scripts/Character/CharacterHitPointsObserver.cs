using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public sealed class CharacterHitPointsObserver : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private GameManager _gameManager;
        
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