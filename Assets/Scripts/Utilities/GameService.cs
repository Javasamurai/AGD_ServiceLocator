using UnityEngine;
using ServiceLocator.Player;

namespace ServiceLocator.Utilities
{
    [DefaultExecutionOrder(100)]
    public class GameService : GenericMonoSingleton<GameService>
    {
        public PlayerService playerService { get; set; }
        [SerializeField] public PlayerScriptableObject playerScriptableObject;

        private void Awake() {
            base.Awake();
            playerService = new PlayerService(playerScriptableObject);
        }

        private void Update() {
            playerService.Update();
        }
    }
}
