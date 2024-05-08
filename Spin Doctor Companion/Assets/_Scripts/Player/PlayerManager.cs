using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;

namespace TripleKD
{
    
    public class PlayerManager : PersistentNetworkSingleton<PlayerManager>
    {
        [HideInInspector] public NetworkVariable<NativeList<PlayerData>> players = new();

        protected override void Awake()
        {
            base.Awake();
        }

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
        }

        public void AddPlayer(PlayerData playerData)
        {
            players.Value.Add(playerData);
        }

        public void RemovePlayer(PlayerData playerData)
        {
            
        }
    }
}