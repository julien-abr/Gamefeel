using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WindController : MonoBehaviour
{
    [SerializeField] private List<Material> _windMaterials = new List<Material>();
    private List<float> _windSpeedValue = new List<float>();

    [Inject] private UpdateBehaviour _uB;
    [SerializeField] private InputSwitchFX _OnWindEffect;
    private void Start()
    {
        _OnWindEffect.SubscribeToUpdate(_uB);
        for (int i = 0; i < _windMaterials.Count; i++)
        {
            _windSpeedValue.Add(_windMaterials[i].GetFloat("_WindSpeed"));
            _windMaterials[i].SetFloat("_WindSpeed", 0f);
        }
    }
    
    public void ActivateWind()
    {
        for (int i = 0; i < _windMaterials.Count; i++)
        {
            _windMaterials[i].SetFloat("_WindSpeed", _windSpeedValue[i]);
        }
    }

    public void DesactivateWind()
    {
        for (int i = 0; i < _windMaterials.Count; i++)
        {
            _windMaterials[i].SetFloat("_WindSpeed", 0);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _windMaterials.Count; i++)
        {
            _windMaterials[i].SetFloat("_WindSpeed", _windSpeedValue[i]);
        }
    }


}
