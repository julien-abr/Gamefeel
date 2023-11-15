using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Vignette", menuName = "ScriptableObjects/PostProcess/Vignette", order = 1)]
public class VignetteSO : ScriptableObject
{
    public float Intensity;
    public Color Color;
    public float Smoothness;
}
