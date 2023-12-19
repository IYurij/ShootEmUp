using UnityEngine;
using UnityEngine.UI;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public class PauseResumeButtonListener : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;

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
