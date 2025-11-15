using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Level3
{
    public class CloseOpenDoor : MonoBehaviour
    {
        private Animator _animator;
        private XRSimpleInteractable interactable;

        private static readonly int OpenParam = Animator.StringToHash("Open");
        private bool isOpen = false;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            interactable = GetComponent<XRSimpleInteractable>();

            if (_animator == null || interactable == null)
            {
                Debug.LogError("Missing Animator or Interactable.");
                return;
            }

            interactable.selectEntered.AddListener(OnDoorToggle);
        }

        private void OnDestroy()
        {
            if (interactable != null)
                interactable.selectEntered.RemoveListener(OnDoorToggle);
        }

        private void OnDoorToggle(SelectEnterEventArgs args)
        {
            isOpen = !isOpen;
            _animator.SetBool(OpenParam, isOpen);

            if (isOpen)
            {
                Debug.Log("Door opened.");
            }
            else
            {
                Debug.Log("Door closed.");
            }
        }
    }
}