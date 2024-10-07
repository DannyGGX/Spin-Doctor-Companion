using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace SpinDoctorCompanion._Scripts.Answer
{
    public class AnswerInputUI : NetworkBehaviour
    {
        [SerializeField] private TMP_InputField answerInput;
        [SerializeField] private Button submitButton;
        

        private void Awake()
        {
            submitButton.onClick.AddListener(SubmitAnswer);
        }

        private void SubmitAnswer()
        {
            //if (!IsOwner) return;
            
            AnswerManager.Instance.AddAnswerServerRpc(answerInput.text);
            
            Debug.Log("SubmitAnswer called");
            AnswerManager.Instance.PrintAnswers();
        }
    }
}