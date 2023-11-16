using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InputInstantFX
{
    [SerializeField] private KeyCode _inputKey;
    private bool _isOn;
    [SerializeField] private UnityEvent _OnEventActivateFX;
    [SerializeField] private UnityEvent _OnEventDesactivateFX;

    public KeyCode InputKey => _inputKey;
    public bool IsOn { get => _isOn; set => _isOn = value; }
    public UnityEvent OnEventActivateFX { get => _OnEventActivateFX; set => _OnEventActivateFX = value; }
    public UnityEvent OnEventFX { get => _OnEventDesactivateFX; set => _OnEventDesactivateFX = value; }

    public void SubscribeToUpdate(UpdateBehaviour uB) => uB.CheckInputEvent += SwitchFX;
    
    public void SwitchFX()
    {
        if (Input.GetKeyDown(_inputKey))
        {
            _isOn = !IsOn;
            if (_isOn)  
                _OnEventActivateFX.Invoke();
            else
                _OnEventDesactivateFX.Invoke();
        }
    }
}
