using UnityEngine;

namespace SpinDoctorCompanion.Avatars
{
    [System.Serializable]
    public struct AvatarData
    {
        public ushort Id; // each PlayerData has a corresponding AvatarId
        public Sprite Sprite;
        
        public AvatarData(ushort id, Sprite sprite)
        {
            Id = id;
            Sprite = sprite;
        }
    }
}