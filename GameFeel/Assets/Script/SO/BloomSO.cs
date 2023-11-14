using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Bloom", menuName = "ScriptableObjects/PostProcess/Bloom", order = 1)]
public class BloomSO : ScriptableObject
{
    public float Threshold;
    public float Intensity;
    [Range(0f, 1f)]
    public float Scatter;
    public Color Tint;
    public float Clamp;
}
