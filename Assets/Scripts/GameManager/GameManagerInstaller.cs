using UnityEngine;
using VContainer;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{ 
    public class GameManagerInstaller : MonoBehaviour
    {
        [SerializeField] private GameObject[] _managementObjects;

        private GameManager _gameManager;
        private IObjectResolver _container;

        [Inject]
        private void Construct(GameManager gameManager, IObjectResolver container)
        {
            _gameManager = gameManager;
            _container = container;
        }

        private void Awake()
        {
            _gameManager.AddListener(_container.Resolve<EnemyCouldownSpawner>());
            _gameManager.AddListener(_container.Resolve<FireInput>());
            _gameManager.AddListener(_container.Resolve<MoveInput>());
            _gameManager.AddListener(_container.Resolve<CharacterFireController>());
            _gameManager.AddListener(_container.Resolve<CharacterMoveController>());
            _gameManager.AddListener(_container.Resolve<CharacterHitPointsObserver>());

            foreach (var go in _managementObjects)
            {
                var listeners = go.GetComponentsInChildren<IGameListener>(true);

                foreach (var listener in listeners)
                {
                    _gameManager.AddListener(listener);
                }
            }
        }
    }
}