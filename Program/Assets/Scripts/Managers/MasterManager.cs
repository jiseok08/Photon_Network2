using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MasterManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform createTransform;
    [SerializeField] WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);

    private IEnumerator Start()
    {
        GameObject clone = null;

        if (PhotonNetwork.IsMasterClient)
        {
            while (true)
            {
                if (PhotonNetwork.CurrentRoom != null && clone == null)
                {
                    clone = PhotonNetwork.InstantiateRoomObject("Robot", Vector3.zero, Quaternion.identity);

                    clone.transform.position = createTransform.position;
                }

                yield return waitForSeconds;
            }
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
    }
}
