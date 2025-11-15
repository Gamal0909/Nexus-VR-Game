using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionManger  : MonoBehaviour
{
    [Header("instructions")]
    [SerializeField] private GameObject inst1;
    [SerializeField] private GameObject inst2;
    [SerializeField] private GameObject inst3;
    [SerializeField] private GameObject inst4;

    [Header("Level Complete")] [SerializeField]
    private GameObject levelComplete;
    [Header("Right Hand")]
    [SerializeField] private GameObject rightHand;

    [Header("Left Hand")]
    [SerializeField] private GameObject leftHand;

    private void Awake()
    {
        HandsState(false);
        StartCoroutine(ShowInstruction(inst1, 4));
    }

    private void HandsState(bool state)
    {
        rightHand.SetActive(state);
        leftHand.SetActive(state);
    }

    private IEnumerator ShowInstruction(GameObject instruction, int seconds)
    {
        instruction.SetActive(true);
        Debug.Log($"{instruction.name} shown");
        yield return new WaitForSeconds(seconds);
        instruction.SetActive(false);
        HandsState(true);
        Debug.Log($"{instruction.name} hidden");
    }

    public void SetInst2()
    {
        HandsState(false);
        StartCoroutine(ShowInstruction(inst2, 4));
    }

    public void SetInst3()
    {
        HandsState(false);
        StartCoroutine(ShowInstruction(inst3, 4));
    }

    public void SetInst4()
    {
        HandsState(false);
        StartCoroutine(ShowInstruction(inst4, 4));
    }

    public void LevelCompleted()
    {
        HandsState(false);
        StartCoroutine(ShowInstruction(levelComplete, 6));
        SceneManager.LoadScene(3);
    }
}