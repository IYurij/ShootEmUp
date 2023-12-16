using UnityEngine;
using UnityEngine.UI;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    public class PauseResumeButtonStateController : MonoBehaviour,
        IGameStartListener,
        IGamePauseListener,
        IGameResumeListener,
        IGameFinishListener
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;

        public void OnStart()
        {
            _pauseButton.gameObject.SetActive(true);
            _resumeButton.gameObject.SetActive(false);
        }

        public void OnPause()
        {
            _pauseButton.gameObject.SetActive(false);
            _resumeButton.gameObject.SetActive(true);
        }

        public void OnResume()
        {
            _pauseButton.gameObject.SetActive(true);
            _resumeButton.gameObject.SetActive(false);
        }

        public void OnFinish()
        {
            _pauseButton.gameObject.SetActive(false);
            _resumeButton.gameObject.SetActive(false);
        }
    }
}
