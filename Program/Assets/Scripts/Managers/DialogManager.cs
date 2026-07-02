using Photon.Pun;
using Photon.Realtime;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform parentTransfrom;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            string message = $"<color=green>{PhotonNetwork.LocalPlayer.NickName} </color>" + " : " + inputField.text;

            Text talk = Instantiate(Resources.Load<Text>("Message"), parentTransfrom);

            talk.text = message;

            inputField.text = "";

            inputField.ActivateInputField();
        }
    }

    public void MakeMessage()
    {

    }
}
