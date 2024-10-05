using Unity.Netcode;

namespace SpinDoctorCompanion._Scripts.Answer
{
    public struct Answer : INetworkSerializable
    {
        public string answerText;
        
        // TODO: Add player or client id to see which player this answer belongs to
        
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref answerText);
        }
    }
}