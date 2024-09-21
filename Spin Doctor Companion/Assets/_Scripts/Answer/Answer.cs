using Unity.Netcode;

namespace SpinDoctorCompanion._Scripts.Answer
{
    public struct Answer : INetworkSerializable
    {
        public string answerText;
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref answerText);
        }
    }
}