using System;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;
    
    public delegate void LightSwitchDelegate();
    public LightSwitchDelegate switchAction;

    private void Awake()
    {
        switchAction = OnToggleLights;
        switchAction += OnLightSwitchSounds;
    }

    private void Start() => currentState = SwitchState.Off;

    public void Interact()
    {
        switchAction?.Invoke();
    }

    private void toggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }
    
    private void OnToggleLights()
    {
        toggleLights();
        GameService.Instance.GetInstructionView().HideInstruction();
    }
    
    private void OnLightSwitchSounds()
    {
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
    }
}
