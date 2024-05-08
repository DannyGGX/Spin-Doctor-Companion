using System.Collections.Generic;
using Unity.Collections;
using UnityEngine.Serialization;

namespace TripleKD
{
    /// <summary>
    /// Deprecated: PlayerManager has its own PlayersData list
    /// </summary>
    public struct PlayersData
    {
        public List<PlayerData> List;
    }
}