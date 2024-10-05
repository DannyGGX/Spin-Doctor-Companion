

using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace SpinDoctorCompanion._Scripts.Answer
{
    
    public class AnswerManager : NetworkSingleton<AnswerManager>
    {
        private NetworkVariable<Answers> answers = new();
        //private Answers answers;

        protected override void Awake()
        {
            base.Awake();
            // answers = new Answers
            // {
            //     answers = new List<Answer>()
            // };
        }

        [GenerateSerializationForType(typeof(Answers))]
        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            answers = new NetworkVariable<Answers>(new Answers
            {
                answers = new List<Answer>()
            }, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        }

        public void GetAnswerFromInput(string answer)
        {
            Answer answerStruct = new Answer();
            answerStruct.answerText = answer;
            answers.Value.answers.Add(answerStruct);
        }
        
        public void ClearAnswers()
        {
            answers.Value.answers.Clear();
        }

        public Answers GetAnswers()
        {
            return answers.Value;
        }

        public void PrintAnswers()
        {
            foreach (Answer answer in answers.Value.answers)
            {
                Debug.Log(answer.answerText);
            }
        }
    }
}