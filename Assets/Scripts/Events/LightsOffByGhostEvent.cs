using UnityEngine;

public class LightsOffByGhostEvent : MonoBehaviour
{
    [SerializeField] private int keyRequiredToTrigger;
    [SerializeField] private SoundType soundType;
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PlayerView>() != null && GameService.Instance.GetPlayerController().KeysEquipped == keyRequiredToTrigger) {
            EventService.Instance.OnLightsOffByGhostEvent.InvokeEvent();
            GameService.Instance.GetSoundView().PlaySoundEffects(soundType);
            this.enabled = false;
        }
    }
}