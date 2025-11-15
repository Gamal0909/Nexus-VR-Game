using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        rightHandModel=GameObject.FindWithTag("Right Hand");
        leftHandModel=GameObject.FindWithTag("Left Hand");
    }

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("No XRGrabInteractable found on the object!");
            return;
        }

        Debug.Log("XRGrabInteractable assigned: " + grabInteractable.name);

        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    private void HideGrabbingHand(SelectEnterEventArgs args)
    {
        Debug.Log("Grab interaction started");
        Debug.Log("Interactor tag: " + args.interactorObject.transform.tag);

        if (args.interactorObject.transform.CompareTag("Left Hand"))
        {
            Debug.Log("Left Hand deactivated");
            leftHandModel.SetActive(false);
        }
        else if (args.interactorObject.transform.CompareTag("Right Hand"))
        {
            Debug.Log("Right Hand deactivated");
            rightHandModel.SetActive(false);
        }
    }


    private void ShowGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Left Hand"))
        {
            Debug.Log("Left Hand reactivated");
            leftHandModel.SetActive(true);
        }
        else if (args.interactorObject.transform.CompareTag("Right Hand"))
        {
            Debug.Log("Right Hand reactivated");
            rightHandModel.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        // Remove listeners to avoid memory leaks
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(HideGrabbingHand);
            grabInteractable.selectExited.RemoveListener(ShowGrabbingHand);
        }
    }
}