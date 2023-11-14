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

    //[Header("VignetteParam")]
    //[SerializeField] private float maxVignetteIntensity;

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
            //_vignette.intensity.value = Mathf.Lerp(0, maxVignetteIntensity, fearValue / maxFearValue);
        }
    }
    
    public void UpdateBloom()
    {
        if (_bloom)
        {
            _bloom
            //
        }
    }
}
