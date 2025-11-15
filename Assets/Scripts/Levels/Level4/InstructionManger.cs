
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level4
{
    public class InstructionManger : MonoBehaviour
    {

        [Header("Instruction")] 
        [SerializeField] private GameObject inst1;
        [SerializeField] private GameObject inst2;
        [SerializeField] private GameObject inst3;
        
        [Header("Level Complete")] [SerializeField]
        private GameObject levelComplete;

        [Header("Right Hand")] [SerializeField]
        private GameObject rightHand;

        [Header("Left Hand")] [SerializeField] private GameObject leftHand;

        private void Start()
        {
            StartCoroutine(RunInstructions());
        }

        private IEnumerator RunInstructions()
        {
            HandsState(false);
            Debug.Log("inst1");
            yield return StartCoroutine(ShowInstruction(inst1, 6));
            Debug.Log("inst2");
            yield return StartCoroutine(ShowInstruction(inst2, 3));

            HandsState(true);
        }


        public void ShowInst3()
        {
            HandsState(false);
            StartCoroutine(ShowInstruction(inst3, 6));
            HandsState(true);
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
        public void LevelCompleted()
        {
            HandsState(false);
            StartCoroutine(ShowInstruction(levelComplete, 6));
            //SceneManager.LoadScene("");
        }
    }
}