using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class VRChecker : MonoBehaviour
{
    [SerializeField] private bool startInVR = true;

    void Awake()
    {
        if (startInVR)
        {
            var xrLoader = XRGeneralSettings.Instance.Manager.activeLoader;

            if (xrLoader == null)
            {
                Debug.Log("No XR loader is active.");
                return;
            }

            // Log XR device status
            Debug.Log("XR Loader Active: " + xrLoader.name);

            // Check if XR display is running
            var displaySubsystems = new List<XRDisplaySubsystem>();
            SubsystemManager.GetInstances(displaySubsystems);

            XRDisplaySubsystem display = displaySubsystems.Find(d => d.running);

            if (display == null)
            {
                Debug.Log("No headset plugged.");
            }
            else
            {
                string deviceName = xrLoader.name;

                if (deviceName.Contains("Mock"))
                {
                    Debug.Log("Using Mock HMD");
                }
                else
                {
                    Debug.Log("We have a headset: " + deviceName);
                }
            }
        }
    }
}
