using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class GameLauncher : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Button _startButton;
        [SerializeField] private Text _countDownText;
        [SerializeField] private int _initCountValue = 3;

        private void Awake()
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
