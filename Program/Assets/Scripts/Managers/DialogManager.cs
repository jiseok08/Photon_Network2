using Photon.Pun;
using Photon.Realtime;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform parentTransfrom;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CreateMessage();
        }
    }

    public void CreateMessage()
    {
        inputField.ActivateInputField();

        if(inputField.text.Length <= 0)
        {
            return;
        }

        string message = $"<color=green>{PhotonNetwork.LocalPlayer.NickName} </color>" + " : " + inputField.text;

        // RPC Target.All : 현재 룸에 있는 모든 클라이언트에게 Talk() 함수를
        // 실행하하는 명령을 전달합니다.
        photonView.RPC("Send", RpcTarget.All, message);

        inputField.text = "";

        inputField.ActivateInputField();
    }

    [PunRPC]
    public void Send(string message)
    {
        Text talk = Instantiate(Resources.Load<Text>("Message"), parentTransfrom);

        talk.text = message;

        Canvas.ForceUpdateCanvases();

        scrollRect.verticalNormalizedPosition = 0.0f;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        string message = $"<color=green>{newPlayer.NickName} Joined the game.</color>";

        photonView.RPC("Send", RpcTarget.All, message);
    }

    public override void OnPlayerLeftRoom(Player newPlayer)
    {
        string message = $"<color=green>{newPlayer.NickName} Left the game.</color>";

        photonView.RPC("Send", RpcTarget.All, message);
    }
}
