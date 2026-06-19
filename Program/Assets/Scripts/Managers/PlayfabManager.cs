using UnityEngine;
using Photon.Pun;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;

public class PlayfabManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string version;

    [SerializeField] TMP_InputField addressInputField;
    [SerializeField] TMP_InputField passwordInputField;

    public void Request()
    {
        var request = new LoginWithEmailAddressRequest 
        { Email = addressInputField.text, 
          Password = passwordInputField.text 
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, Success, Failed);
    }

    public void Success(LoginResult loginResult)
    {
        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), Success, Failed);

        PhotonNetwork.AutomaticallySyncScene = false; // 방장을 따라가지 않음

        PhotonNetwork.GameVersion = version; // 버전 맞추기

        PhotonNetwork.ConnectUsingSettings(); // Master Server로 연결하는 함수
    }

    public void Open()
    {
        PanelManager.Instance.Open(Panel.Subscribe);
    }

    public override void OnConnectedToMaster()
    {
        // 특정 로비를 생성하여 진입하는 함수
        PhotonNetwork.JoinLobby();
    }

    public void Success(GetAccountInfoResult getAccountInfoRequest)
    {
        PhotonNetwork.LocalPlayer.NickName = getAccountInfoRequest.AccountInfo?.Username;
    }

    public void Failed(PlayFabError playFabError)
    {
        PanelManager.Instance.Open(Panel.Error, playFabError.GenerateErrorReport());
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
