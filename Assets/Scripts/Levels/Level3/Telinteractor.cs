using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Level3
{
    public class Telinteractor : MonoBehaviour
    {
        private XRBaseInteractable Interactable;
        public GameObject NumPad;

        void Start()
        {
            if (Interactable == null) Interactable = GetComponent<XRSimpleInteractable>();
            Interactable.selectEntered.AddListener(viewnumpad);
        }

        private void viewnumpad(SelectEnterEventArgs args)
        {
            NumPad.SetActive(true);
        }


    }
}