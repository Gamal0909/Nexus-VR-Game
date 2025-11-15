using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // If you're using TextMeshPro

namespace Level3
{
    public class NumpadController : MonoBehaviour
    {
        [SerializeField] private GameObject numpad;
        [SerializeField] private TMP_Text displayText; // Drag your TMP Text here
        private string currentInput = "";
        private InstructionManger _instructionManger;

        private void Awake()
        {
            _instructionManger = GetComponent<InstructionManger>();
        }

        public void PressNumber(int number)
        {
            if (currentInput.Length < 3)
            {
                currentInput += number.ToString();
                displayText.text = currentInput;

                if (currentInput.Length == 3)
                {
                    CheckCode();
                }
            }
        }

        private void CheckCode()
        {
            if (currentInput == "180")
            {
                numpad.SetActive(false);
                _instructionManger.LevelCompleted();
                Debug.Log("✅ Correct code! Puzzle completed.");
                // Call your success logic here (animation, unlock, etc)
            }
            else if(currentInput.Length>=3)
            {
                Debug.Log("❌ Incorrect code. Try again.");
                StartCoroutine(ResetInput());
            }
        }

        private IEnumerator ResetInput()
        {
            yield return new WaitForSeconds(1f);
            currentInput = "";
            displayText.text = "";
        }

        public void ClearInput()
        {
            currentInput = "";
            displayText.text = "";
        }
    }
}