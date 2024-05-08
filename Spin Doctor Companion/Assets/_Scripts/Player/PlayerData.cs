using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

namespace TripleKD
{
	
	public struct PlayerData : INetworkSerializable
	{
		public FixedString32Bytes Name;
		public ushort Id;
		public ushort Score;
		public ushort AvatarId;
		
		public PlayerData(FixedString32Bytes name, ushort id, ushort score, ushort avatarId)
		{
			Name = name;
			Id = id;
			Score = score;
			AvatarId = avatarId;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
			serializer.SerializeValue(ref Name);
			serializer.SerializeValue(ref Id);
			serializer.SerializeValue(ref Score);
			serializer.SerializeValue(ref AvatarId);
		}
	}
}
