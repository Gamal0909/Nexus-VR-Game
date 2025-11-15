using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Level4
{
    public class FireController : MonoBehaviour
    {
        
        [SerializeField] private InstructionManger _instructionManger;
        [SerializeField] private GameObject fire;
        private XRBaseInteractable _interactable;
        private Animator _animator;
        
        private string liq = "liq";

        private void Awake()
        {
            if(_interactable==null)_interactable = GetComponent<XRSimpleInteractable>();
            if(_animator==null)_animator = GetComponent<Animator>();
            _interactable.selectEntered.AddListener(Movetiq);
        }

        private void Movetiq(SelectEnterEventArgs args)
        {
            _animator.SetBool(liq, true);
            _instructionManger.ShowInst3();
            new WaitForSeconds(2);
            fire.SetActive(false);

        }
    }
}