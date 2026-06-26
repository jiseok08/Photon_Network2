using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] List<Transform> createPositions = new List<Transform>();

    private void Start()
    {
        Create();
    }

    public void Create()
    {
        int index = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        PhotonNetwork.Instantiate("Character", createPositions[index].position, Quaternion.identity);
    }
}
