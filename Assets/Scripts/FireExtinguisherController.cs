using DefaultNamespace;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisherController : MonoBehaviour
{
    [SerializeField] private ParticleSystem smoke;
    [SerializeField] private Transform sprayPoint;
    [SerializeField] private float sprayRange = 5f;
    [SerializeField] private LayerMask fireLayer;

    private bool isHeld = false;
    private bool isSpraying = false;
    private XRBaseControllerInteractor controllerInteractor;

    void Start()
    {
        smoke.Stop();
        Debug.Log("Smoke stopped in Start()");
    }

    void Update()
    {
        if (!isHeld || controllerInteractor == null) return;

        // Check trigger button state from controller
        if (controllerInteractor.xrController.selectInteractionState.activatedThisFrame)
        {
            StartSpraying();
        }
        else if (controllerInteractor.xrController.selectInteractionState.deactivatedThisFrame)
        {
            StopSpraying();
        }

        if (isSpraying)
        {
            Ray ray = new Ray(sprayPoint.position, sprayPoint.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, sprayRange, fireLayer))
            {
                Debug.Log("Ray hit: " + hit.collider.name);
                if (hit.collider.CompareTag("Fire"))
                {
                    Fire fire = hit.collider.GetComponent<Fire>();
                    if (fire != null)
                    {
                        fire.Extinguish(Time.deltaTime);
                        Debug.Log("Extinguishing fire...");
                    }
                }
            }
        }
    }

    public void Grab(XRBaseInteractor interactor)
    {
        isHeld = true;
        controllerInteractor = interactor as XRBaseControllerInteractor;

        if (controllerInteractor != null)
        {
            Debug.Log("Controller interactor assigned.");
        }
        else
        {
            Debug.LogWarning("Grabbed object, but interactor is not a controller!");
        }
    }

    public void Release()
    {
        isHeld = false;
        StopSpraying();
        controllerInteractor = null;
        Debug.Log("Fire extinguisher released.");
    }

    private void StartSpraying()
    {
        if (!isSpraying)
        {
            isSpraying = true;
            smoke.Play();
            Debug.Log("Started spraying.");
        }
    }

    private void StopSpraying()
    {
        if (isSpraying)
        {
            isSpraying = false;
            smoke.Stop();
            Debug.Log("Stopped spraying.");
        }
    }
}
