using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InputFX
{
    [SerializeField] private KeyCode _inputKey;
    private bool _isOn;
    [SerializeField] private UnityEvent _OnEventFX;

    public KeyCode InputKey => _inputKey;
    public bool IsOn { get => _isOn; set => _isOn = value; }
    public UnityEvent OnEventFX { get => _OnEventFX; set => _OnEventFX = value; }

    public void SubscribeToUpdate(UpdateBehaviour uB) => uB.CheckInputEvent += SwitchFX;
    
    public void SwitchFX()
    {
        if (Input.GetKeyDown(_inputKey))
            _isOn = !IsOn;
    }

    public void TriggerEvent()
    {
        if (_isOn)
            _OnEventFX.Invoke();
    }
}
