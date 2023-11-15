using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : MonoBehaviour
{
    private Volume _postProcessingVolume;
    
    //Effects
    private Vignette _vignette;
    private Bloom _bloom;

    [Header("Scriptables")]
    [SerializeField] private BloomSO BloomScriptable;
    [SerializeField] private VignetteSO VignetteScriptable;

    private void Start()
    {
        _postProcessingVolume = GetComponent<Volume>();
        _postProcessingVolume.profile.TryGet(out _vignette);
        _postProcessingVolume.profile.TryGet(out _bloom);
    }

    public void UpdateVignette()
    {
        if (_vignette)
        {
            if (_vignette.active == false) { _vignette.active = true; }
            _vignette.intensity.value = VignetteScriptable.Intensity;
            _vignette.color.value = VignetteScriptable.Color;
            _vignette.smoothness.value = VignetteScriptable.Smoothness;
        }
    }
    
    public void UpdateBloom()
    {
        if (_bloom)
        {
            if (_bloom.active == false) { _bloom.active = true; }
            _bloom.threshold.value = BloomScriptable.Threshold;
            _bloom.intensity.value = BloomScriptable.Intensity;
            _bloom.scatter.value = BloomScriptable.Scatter;
            _bloom.tint.value = BloomScriptable.Tint;
            _bloom.clamp.value = BloomScriptable.Clamp;
        }
    }

    public void ResetVignette()
    {
        _vignette.active = false;
    }

    public void ResetBloom()
    {
        _bloom.active = false;
    }
}
