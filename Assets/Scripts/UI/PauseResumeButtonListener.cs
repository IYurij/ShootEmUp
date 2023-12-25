using UnityEngine;
using UnityEngine.UI;
using VContainer;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public class PauseResumeButtonListener : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        private GameManager _gameManager;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void OnStart()
        {
            _pauseButton.onClick.AddListener(PauseGame);
            _resumeButton.onClick.AddListener(ResumeGame);
        }

        public void OnFinish()
        {
            _pauseButton.onClick.RemoveListener(PauseGame);
            _resumeButton.onClick.RemoveListener(ResumeGame);
        }

        private void ResumeGame()
        {
            _gameManager.ResumeGame();
        }

        private void PauseGame()
        {
            _gameManager.PauseGame();
        }
    }
}
