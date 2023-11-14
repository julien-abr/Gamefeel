using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : MonoBehaviour
{
    private Volume _postProcessingVolume;
    [SerializeField] private float vignetteIntensity;
    private Vignette _vignette;

    [Header("VignetteParam")]
    [SerializeField] private float maxVignetteIntensity;

    private void Start()
    {
        _postProcessingVolume = GetComponent<Volume>();
        _postProcessingVolume.profile.TryGet(out _vignette);
    }

    private void Update()
    {
        //_vignette.intensity.value = Mathf.Lerp(0, maxVignetteIntensity, fearValue / maxFearValue);
    }
}
