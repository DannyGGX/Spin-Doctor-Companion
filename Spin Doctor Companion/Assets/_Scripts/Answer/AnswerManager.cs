

using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace SpinDoctorCompanion._Scripts.Answer
{
    
    public class AnswerManager : NetworkBehaviour
    {
        public static AnswerManager Instance;
        private void Awake()
        {
            // Add singleton code
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private NetworkVariable<Answers> NetworkedAnswers = new NetworkVariable<Answers>(new Answers
        {
            answers = new List<Answer>()
        }, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

        public void GetAnswerFromInput(string answer)
        {
            Answer answerStruct = new Answer();
            answerStruct.answerText = answer;
            NetworkedAnswers.Value.answers.Add(answerStruct);
        }

        [ServerRpc(RequireOwnership = false)]
        public void AddAnswerServerRpc(string answer)
        {
            Debug.Log("AddAnswerServerRpc executed on server");
            Answer answerStruct = new Answer();
            answerStruct.answerText = answer;
            NetworkedAnswers.Value.answers.Add(answerStruct);
        }
        
        public void ClearAnswers()
        {
            NetworkedAnswers.Value.answers.Clear();
        }

        public Answers GetAnswers()
        {
            return NetworkedAnswers.Value;
        }

        public void PrintAnswers()
        {
            foreach (Answer answer in NetworkedAnswers.Value.answers)
            {
                Debug.Log(answer.answerText);
            }
        }
    }
}