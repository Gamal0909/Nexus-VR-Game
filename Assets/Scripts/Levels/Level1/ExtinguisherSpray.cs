using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ExtinguisherSpray : MonoBehaviour
{
    [Header("Spray Settings")]
    [SerializeField] private ParticleSystem sprayEffect;
    [SerializeField] private float maxSprayTime = 20f;

    private float remainingTime;
    private bool isSpraying = false;

    private string currentHandTag = "";
    private ActionBasedController controller;
    private FireExHand _fireExHand;

    private void Start()
    {
        _fireExHand = GetComponent<FireExHand>();
        currentHandTag = _fireExHand.parentTag;
        remainingTime = maxSprayTime;

        // Find smoke particle system if not manually assigned
        if (sprayEffect == null)
        {
            GameObject smoke = GameObject.FindGameObjectWithTag("Spray");
            if (smoke != null)
            {
                sprayEffect = smoke.GetComponent<ParticleSystem>();
                Debug.Log("✅ Spray found via tag: Smoke");
            }
            else
            {
                Debug.LogError("❌ No GameObject with tag 'Smoke' found!");
            }
        }

        // Detect which hand is holding us
        if (transform.parent != null)
        {
            string parentTag = transform.parent.tag;
            currentHandTag = parentTag;
            Debug.Log("👐 Fire extinguisher parent tag: " + parentTag);

            if (parentTag == "LeftHand")
            {
                GameObject actionBasedController = GameObject.FindWithTag("RightHand");
                controller=actionBasedController.GetComponent<ActionBasedController>();
            }
            else if (parentTag == "RightHand")
            {
                controller = GameObject.FindWithTag(parentTag)?.GetComponentInParent<ActionBasedController>();
            }

            if (controller == null)
            {
                Debug.LogError("❌ Could not find ActionBasedController for tag: " + parentTag);
            }
        }
        else
        {
            Debug.LogWarning("⚠️ Fire extinguisher has no parent. Cannot detect which hand is holding it.");
        }
    }

    private void Update()
    {
        if (controller == null || sprayEffect == null || remainingTime <= 0f)
        {
            StopSpray();
            return;
        }

        float gripValue = controller.selectActionValue.action.ReadValue<float>();
        Debug.Log($"🎮 [{currentHandTag}] Grip value: {gripValue}");

        if (gripValue > 0.5f && !isSpraying)
            StartSpray();
        else if (gripValue <= 0.5f && isSpraying)
            StopSpray();

        if (isSpraying)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0f)
            {
                Debug.Log("💨 Spray depleted.");
                StopSpray();
            }
        }
    }

    private void StartSpray()
    {
        if (!sprayEffect.isPlaying)
        {
            sprayEffect.Play();
            isSpraying = true;
            Debug.Log("🚿 Spray started.");
        }
    }

    private void StopSpray()
    {
        if (sprayEffect.isPlaying)
        {
            sprayEffect.Stop();
            isSpraying = false;
            Debug.Log("🛑 Spray stopped.");
        }
    }
}
