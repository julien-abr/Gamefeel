using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBehaviour : MonoBehaviour
{
    private Action _CheckInputEvent;
    public Action CheckInputEvent { get => _CheckInputEvent; set => _CheckInputEvent = value; }

    void Update() => _CheckInputEvent();   
}
