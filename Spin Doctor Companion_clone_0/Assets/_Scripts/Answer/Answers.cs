using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;

namespace SpinDoctorCompanion._Scripts.Answer
{
    
    public struct Answers : INetworkSerializeByMemcpy // INetworkSerializable is not able to serialize lists
    {
        public List<Answer> answers;
    }
}