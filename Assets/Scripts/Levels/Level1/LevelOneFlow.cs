using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LevelOneFlow : MonoBehaviour
{
    public InstructionManager instructionManager;
    public GameObject levelCompleteCanvas;
    
    void Awake()
    {
        //if(fire)fire.SetActive(false);
        //if(fireExtinguisher)fireExtinguisher.SetActive(false);
        if(levelCompleteCanvas)levelCompleteCanvas.SetActive(false);
        
        instructionManager.ShowInstruction("Open The Door", 4f);
    }
    public void OnDoorOpened()
    {
        Debug.Log("OnDoorOpened");
        instructionManager.ShowInstruction("Find the fire extinguisher and spray it to put out the fire. ", 4f);
        
    }
    void ShowLevelComplete()
    {
        levelCompleteCanvas.SetActive(true);
    }
}
