using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class RefreshLobby : MonoBehaviour
{
    public void OnClick_RefreshRoom()
    {
        //ルームにいないとき
        if (!PhotonNetwork.InRoom)
        {
            PhotonNetwork.JoinLobby();
            print("ロビーに再接続");
        }
        else
        {
            PhotonNetwork.LeaveLobby();  //ルームを出る
            print("ロビーから切断");
        }
    }

}
