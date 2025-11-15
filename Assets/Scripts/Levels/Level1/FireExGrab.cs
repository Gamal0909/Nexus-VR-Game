using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExGrab : MonoBehaviour
{
    [Header("Hand Socket & Models & Ray")]
    public Transform leftHandSocket;
    public GameObject leftHandModel;
    public GameObject leftHandRay;
    public Transform rightHandSocket;
    public GameObject rightHandModel;
    public GameObject rightHandRay;

    [Header("Fire Extinguisher Prefab")]
    [SerializeField] private GameObject fireExPrefab;

    private XRSimpleInteractable interactable;
    public bool isGrabbed ;
    public bool isGrabbedLeft;
    public bool isGrabbedRight;
    private int leftHandLayer;
    private int rightHandLayer;

    private void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable == null)
        {
            Debug.LogError("Missing XRSimpleInteractable!");
            return;
        }

        leftHandLayer = LayerMask.NameToLayer("LeftHand");
        rightHandLayer = LayerMask.NameToLayer("RightHand");

        interactable.selectEntered.AddListener(OnGrab);
        isGrabbed = false;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (isGrabbed) return;

        int layer = args.interactorObject.transform.gameObject.layer;
        Debug.Log("Grabbed by layer: " + layer + " (" + LayerMask.LayerToName(layer) + ")");

        if (layer == leftHandLayer)
        {
            ReplaceHandWithExtinguisher(leftHandSocket, leftHandModel, leftHandRay, args.interactorObject);
            isGrabbedLeft = true;
        }
        else if (layer == rightHandLayer)
        {
            ReplaceHandWithExtinguisher(rightHandSocket, rightHandModel, rightHandRay, args.interactorObject);
            isGrabbedRight = true;
        }
        else
        {
            Debug.LogWarning("Grabbed by unknown object/layer.");
        }

        isGrabbed = true;
        Destroy(gameObject); // Destroy placeholder after grab
    }

    private void ReplaceHandWithExtinguisher(Transform socket, GameObject handModel, GameObject ray, IXRInteractor interactor)
    {
        if (handModel) handModel.SetActive(false);
        if (ray) ray.SetActive(false);

        if (fireExPrefab != null && socket != null)
        {
            GameObject fireEx = Instantiate(fireExPrefab, socket);
            fireEx.transform.localPosition = Vector3.zero;
            fireEx.transform.localRotation = Quaternion.identity;

            // Disable physics
            if (fireEx.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
            if (fireEx.TryGetComponent<Collider>(out var col))
                col.enabled = false;

            // Link to spray system
            if (fireEx.TryGetComponent<ExtinguisherSpray>(out var sprayScript) && interactor is XRBaseInteractor xrInteractor)
            {
                //sprayScript.SetInteractor(xrInteractor);
                Debug.Log("Interactor linked to spray script.");
            }
        }
        else
        {
            Debug.LogWarning("Missing fire extinguisher prefab or socket.");
        }
    }

    private void OnDestroy()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnGrab);
    }
}
