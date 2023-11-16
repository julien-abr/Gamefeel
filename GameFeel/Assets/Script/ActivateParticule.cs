using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticule : MonoBehaviour
{
    public void Activate()
    {
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
    }
}
