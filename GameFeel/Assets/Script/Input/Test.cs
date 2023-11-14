using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private UpdateBehaviour _uB;

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
