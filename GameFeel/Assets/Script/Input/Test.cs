using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    [Inject] private UpdateBehaviour _uB;

    public InputFX t;

    private void Start()
    {
        t.SubscribeToUpdate(_uB);     
    }

    private void Update()
    {
        t.TriggerEvent();
    }
}
