using UnityEngine;

public class KeyView : MonoBehaviour, IInteractable
{
    [SerializeField] GameUIView gameUIView;
    private int keysEquipped;
    public void Interact()
    {
        GameService.Instance.GetInstructionView().HideInstruction();
        // GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.KeyPickUp);
        // GameService.Instance.GetPlayerController().KeysEquipped++;
        keysEquipped++;
        EventService.Instance.OnKeyPickedUp.InvokeEvent(keysEquipped);
        gameUIView.UpdateKeyText();
        gameObject.SetActive(false);
    }
}
