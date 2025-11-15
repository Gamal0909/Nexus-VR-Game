using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionText;
    [SerializeField] private GameObject instructionCanvas;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject LeftHand;
    
    public void ShowInstruction(string text, float duration)
    {
        Debug.Log("ShowInstruction");
        instructionText.text = text;
        instructionCanvas.SetActive(true);
        if (RightHand) RightHand.SetActive(false); 
        if (LeftHand) LeftHand.SetActive(false); 

        Invoke(nameof(HideInstruction), duration);
    }
    
    void HideInstruction()
    {
        Debug.Log("ShowInstruction");
        instructionCanvas.SetActive(false);
        if (LeftHand) LeftHand.SetActive(true); // enable movement again
        if (RightHand) RightHand.SetActive(true);
    }

    public void OkButton()
    {
        Debug.Log("Pressssed");
        HideInstruction();
    }
}
