using UnityEngine;
using static ShootEmUp.Listeners;

namespace ShootEmUp
{
    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var manager = GetComponent<GameManager>();
            
            var listeners = GetComponentsInChildren<IGameListener>(true);

            foreach (var listener in listeners)
            {
                manager.AddListener(listener);
            }
        }
    }
}