using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public Material material;
    public float windSpeedModifer;

    public void Update()

    {
        material.SetFloat("_WindSpeed", 0f);
    }
}
