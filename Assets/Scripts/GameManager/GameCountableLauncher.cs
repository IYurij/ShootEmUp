using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace ShootEmUp
{
    public class GameCountableLauncher : MonoBehaviour, IInitializable
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Text _countDownText;
        [SerializeField] private int _initCountValue = 3;

        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Initialize()
        {
            _countDownText.gameObject.SetActive(false);

            _startButton.onClick.AddListener(StartCountdown);
        }

        private void StartCountdown()
        {
            _startButton.gameObject.SetActive(false);
            _countDownText.gameObject.SetActive(true);
            _startButton.onClick.RemoveListener(StartCountdown);

            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown()
        {
            for (int i = _initCountValue; i > 0; i--)
            {
                _countDownText.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            _countDownText.gameObject.SetActive(false);
            _gameManager.StartGame();
        }
    }
}
