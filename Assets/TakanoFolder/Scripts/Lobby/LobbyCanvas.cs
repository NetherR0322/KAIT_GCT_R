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
    public Text PlayerCoun2;
    string text2;
    private void Update()
    {
        text = PhotonNetwork.CountOfPlayersOnMaster.ToString();
        text2 = PhotonNetwork.CountOfPlayers.ToString();
        PlayerCount.text = "待機プレイヤー:" + text+"人";
        PlayerCoun2.text = "接続プレイヤー:"+text2+"人";
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
