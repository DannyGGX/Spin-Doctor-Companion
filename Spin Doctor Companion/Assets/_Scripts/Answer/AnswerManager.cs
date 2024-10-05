

using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace SpinDoctorCompanion._Scripts.Answer
{
    
    public class AnswerManager : NetworkSingleton<AnswerManager>
    {
        //private NetworkVariable<Answers> answers = new();
        private Answers answers;

        protected override void Awake()
        {
            base.Awake();
            answers = new Answers
            {
                answers = new List<Answer>()
            };
        }

        public void GetAnswerFromInput(string answer)
        {
            Answer answerStruct = new Answer();
            answerStruct.answerText = answer;
            answers.answers.Add(answerStruct);
        }
        
        public void ClearAnswers()
        {
            answers.answers.Clear();
        }

        public Answers GetAnswers()
        {
            return answers;
        }

        public void PrintAnswers()
        {
            foreach (Answer answer in answers.answers)
            {
                Debug.Log(answer.answerText);
            }
        }
    }
}