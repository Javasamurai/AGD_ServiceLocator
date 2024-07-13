using UnityEngine;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;

namespace ServiceLocator.Utilities
{
    [DefaultExecutionOrder(100)]
    public class GameService : GenericMonoSingleton<GameService>
    {
        public PlayerService playerService { get; set; }
        public SoundService soundService { get; set; }
        public UIService uiService => UIService;

        [SerializeField] private UIService UIService;
        [SerializeField] private AudioSource audioEffects;
        [SerializeField] private AudioSource backgroundMusic;

        [SerializeField] public PlayerScriptableObject playerScriptableObject;
        [SerializeField] public SoundScriptableObject soundScriptableObject;

        private void Awake() {
            base.Awake();
            playerService = new PlayerService(playerScriptableObject);
            soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        }

        private void Update() {
            playerService.Update();
        }
    }
}
