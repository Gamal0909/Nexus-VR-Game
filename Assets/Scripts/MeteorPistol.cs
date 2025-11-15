using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem smoke;

    private void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartFire());
        grabInteractable.deactivated.AddListener(x => EndFire());

    }

        public void StartFire()
        {
            smoke.Play();
        }
        public void EndFire()
        {
            smoke.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
