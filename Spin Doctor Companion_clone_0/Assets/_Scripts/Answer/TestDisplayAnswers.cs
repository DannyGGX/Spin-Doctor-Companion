using System;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils;

namespace SpinDoctorCompanion._Scripts.Answer
{
    public class TestDisplayAnswers : NetworkBehaviour
    {
        [SerializeField] private Button showAnswersButton;
        [SerializeField] private VerticalLayoutGroup layoutGroup;
        private List<TextMeshProUGUI> _answersText;

        private void Awake()
        {
            //if (!IsOwner) return;
            
            Debug.Log("Added button listener");
            showAnswersButton.onClick.AddListener(ShowAnswersButtonPressed);
        }

        /// <summary>
        /// This method is separate from the RPC so that the answers are only cleared once and the other network entities don't clear them
        /// </summary>
        private void ShowAnswersButtonPressed()
        {
            Debug.Log("ShowAnswersButtonPressed called");
            //if (!IsOwner) return;
            
            _answersText = new List<TextMeshProUGUI>();
            ClearAnswers();
            // Get the answers from the Answer Manager on the server and then show them on all clients
            GetAndShowAnswersServerRpc();
        }

        [ServerRpc(RequireOwnership = false)]
        private void GetAndShowAnswersServerRpc()
        {
            Debug.Log("GetAnswersServerRPC called");
            Answers currentAnswers = AnswerManager.Instance.GetAnswers();
            ShowAnswersClientRpc(currentAnswers);
        }
        
        [ClientRpc]
        private void ShowAnswersClientRpc(Answers answers)
        {
            Debug.Log("ShowAnswersRPC called");
            for (int i = 0; i < answers.answers.Count; i++)
            {
                CreateAnswerEntry(i, answers.answers[i]);
            }
        }

        private void CreateAnswerEntry(int index, Answer answer)
        {
            var answerEntry = new GameObject("AnswerEntry" + index);
            answerEntry.transform.SetParent(layoutGroup.transform);
            answerEntry.transform.localScale = Vector3.one;
            var text = answerEntry.AddComponent<TextMeshProUGUI>();
            text.text = answer.answerText;
            text.fontSize = 30;
            _answersText.Add(text);
        }
        
        private void ClearAnswers()
        {
            _answersText.Clear();
            layoutGroup.gameObject.DestroyChildren();
        }
    }
}