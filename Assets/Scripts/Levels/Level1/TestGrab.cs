using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
public class TestGrab : MonoBehaviour
{
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(ctx =>
        {
            Debug.Log("Grabbed by " + ctx.interactorObject.transform.name);
        });
    }
}