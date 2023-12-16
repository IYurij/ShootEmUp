using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        [SerializeField] private GameObject[] _managementObjects;

        private void Awake()
        {
            var manager = GetComponent<GameManager>();

            foreach (var go in _managementObjects)
            {
                var listeners = go.GetComponentsInChildren<IGameListener>(true);

                foreach (var listener in listeners)
                {
                    manager.AddListener(listener);
                }
            }
        }
    }
}