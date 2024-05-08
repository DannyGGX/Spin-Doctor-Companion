using UnityEngine;

namespace TripleKD.Avatars
{
    // Create 1 and access from Assets/Resources folder
    [CreateAssetMenu(fileName = "Avatars", menuName = "Scriptable Object/Avatars", order = 1)]
    public class AvatarsSO : ScriptableObject
    {
        [field: SerializeField] public AvatarData[] Array { get; private set; }
    }
}