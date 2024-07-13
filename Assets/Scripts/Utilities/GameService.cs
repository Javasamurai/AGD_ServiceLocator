using UnityEngine;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Map;
using ServiceLocator.Wave;

namespace ServiceLocator.Utilities
{
    [DefaultExecutionOrder(100)]
    public class GameService : GenericMonoSingleton<GameService>
    {
        public PlayerService playerService { get; set; }
        public SoundService soundService { get; set; }
        public MapService mapService { get; set; }
        public WaveService waveService { get; set; }
        public UIService uiService => UIService;

        [SerializeField] private UIService UIService;
        [SerializeField] private AudioSource audioEffects;
        [SerializeField] private AudioSource backgroundMusic;

        [SerializeField] public PlayerScriptableObject playerScriptableObject;
        [SerializeField] public SoundScriptableObject soundScriptableObject;
        [SerializeField] private MapScriptableObject mapScriptableObject;
        [SerializeField] private WaveScriptableObject waveScriptableObject;
 

        private void Awake() {
            base.Awake();
            playerService = new PlayerService(playerScriptableObject);
            soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
            mapService = new MapService(mapScriptableObject);
            waveService = new WaveService(waveScriptableObject);
        }

        private void Update() {
            playerService.Update();
        }
    }
}
