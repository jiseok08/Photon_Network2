using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] double time;
    [SerializeField] double initializeTime;

    private void Awake()
    {
        time = 60;
        initializeTime = PhotonNetwork.Time;
    }

    private void Update()
    {
        time = PhotonNetwork.Time - initializeTime;

        Debug.Log(time);
    }
}
