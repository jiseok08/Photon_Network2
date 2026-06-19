using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dictionary<string, GameObject> list = new Dictionary<string, GameObject>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
    }
}
