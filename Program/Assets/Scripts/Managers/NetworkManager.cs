using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform createPositon;

    private void Start()
    {
        Create();
    }

    public void Create()
    {
        PhotonNetwork.Instantiate("Character", createPositon.position, Quaternion.identity);
    }
}
