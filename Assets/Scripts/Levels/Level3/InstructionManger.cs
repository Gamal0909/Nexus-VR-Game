using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level3
{
    public class InstructionManger : MonoBehaviour
    {

        [Header("Level Complete")] [SerializeField]
        private GameObject levelComplete;

        [Header("Right Hand")] [SerializeField]
        private GameObject rightHand;

        [Header("Left Hand")] [SerializeField] private GameObject leftHand;

        

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
            SceneManager.LoadScene(4);
        }
    }
}