using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyCanvas : MonoBehaviour
{
    //---ロビーキャンバス(ルーム作ったりするやつ)---//
    [SerializeField]
    private RoomLayoutGroup _roomLayoutGroup;
    private RoomLayoutGroup RoomLayoutGroup
    {
        get { return _roomLayoutGroup; }
    }
    public Text PlayerCount;
    string text;
    private void Update()
    {
        text = PhotonNetwork.CountOfPlayersOnMaster.ToString();
        PlayerCount.text = "待機プレイヤー:" + text+"人";
    }
    public void OnClickJoinRoom(string roomName)
    {
        if (PhotonNetwork.JoinRoom(roomName))
        {

        }
        else
        {
            print("Join room failed");
        }
    }
}
