using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace DefaultNamespace
{
    public class FireExtinguisher : MonoBehaviour
    {
        [SerializeField] private ParticleSystem smoke;
        [SerializeField] private Transform sprayPoint;
        [SerializeField] private float sprayRange = 5f;
        [SerializeField] private LayerMask fireLayer;

        private XRGrabInteractable xrGrabInteractable;
        private bool isSpraying = false;

        private void Start()
        {
            
            xrGrabInteractable = GetComponent<XRGrabInteractable>();
            xrGrabInteractable.activated.AddListener(OnSprayStart);
            xrGrabInteractable.deactivated.AddListener(OnSprayStop);
            smoke.Stop();
        }

        private void OnSprayStart(ActivateEventArgs args)
        {
            smoke.Play();
            isSpraying = true;
        }

        private void OnSprayStop(DeactivateEventArgs args)
        {
            isSpraying = false;
            smoke.Stop();
        }
        /*void Update()
        {
            // VR input (for real gameplay)
            // isSpraying would be toggled via XR in real mode

            // PC Testing Input
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                OnSprayStart();
            }
            else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            {
                OnSprayStop();
            }

            if (isSpraying)
            {
                SprayRay();
            }
        }*/
        void Update()
        {
            if (isSpraying)
            {
                Ray ray = new Ray(sprayPoint.position, sprayPoint.forward);
                if (Physics.Raycast(ray, out RaycastHit hit, sprayRange, fireLayer))
                {
                    if (hit.collider.CompareTag("Fire"))
                    {
                        Fire fire = hit.collider.GetComponent<Fire>();
                        if (fire != null)
                        {
                            fire.Extinguish(Time.deltaTime);
                        }
                    }
                }
            }
        }
    }
}    