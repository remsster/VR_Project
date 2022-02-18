using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private ParticleSystem PS;

    private void Awake()
    {
        PS = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.Button.One))
        {
            PS.Play();
        }
        else if(Input.GetButtonUp("Fire1") || OVRInput.GetUp(OVRInput.Button.One))
        {
            PS.Stop();
        }
    }
}
