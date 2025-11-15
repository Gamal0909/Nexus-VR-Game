using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenCloseDoor : MonoBehaviour
{
    [SerializeField] private LevelOneFlow _levelOneFlow;

    private Animator _animator;
    private XRBaseInteractable interactable;
    private string open = "Open";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable == null)
        {
            Debug.LogError("No XRBaseInteractable found on the object!");
            return;
        }
        interactable.selectEntered.AddListener(GrabDoor);
        interactable.selectExited.AddListener(ShowInstruction);
    }

    private void GrabDoor(SelectEnterEventArgs arg0)
    {
        Debug.Log("Grab");
        _animator.SetBool(open, true);
    }
    private void ShowInstruction(SelectExitEventArgs arg0)
    {
        Debug.Log("Released");
        StartCoroutine(DelayedInstruction(2));
    }
    private IEnumerator DelayedInstruction(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _levelOneFlow.OnDoorOpened();
    }
}