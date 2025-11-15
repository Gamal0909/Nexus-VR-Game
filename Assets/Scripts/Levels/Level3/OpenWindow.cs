using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Level3;

namespace Level3
{
    public class OpenWindow : MonoBehaviour
    {
        private Animator _animator;
        private XRSimpleInteractable interactable;
        private static readonly int OpenHash = Animator.StringToHash("Open");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            if (_animator == null)
                Debug.LogError("❌ Animator not found on " + gameObject.name);

            interactable = GetComponent<XRSimpleInteractable>();
            if (interactable == null)
                Debug.LogError("❌ XRSimpleInteractable not found on " + gameObject.name);
        }

        private void OnEnable()
        {
            if (interactable != null)
                interactable.selectEntered.AddListener(OpenWindows);
        }

        private void OnDisable()
        {
            if (interactable != null)
                interactable.selectEntered.RemoveListener(OpenWindows);
        }

        private void OpenWindows(SelectEnterEventArgs args)
        {
            if (_animator != null)
            {
                Debug.Log("✅ Window open triggered.");
                _animator.SetBool(OpenHash, true);
            }

        }
    }
}