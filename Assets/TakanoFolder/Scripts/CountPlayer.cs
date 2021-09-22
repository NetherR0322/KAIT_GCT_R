using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CountPlayer : MonoBehaviour
{
    public Text PlayerCount;
    string text;
    public Text PlayerCoun2;
    string text2;
    public Text PlayerCoun3;
    string text3;
    int countPlayerMaster;
    int countPlayer;
    int countRoom;
    // Start is called before the first frame update
    void Start()
    {
        countPlayerMaster = PhotonNetwork.CountOfPlayersOnMaster;
        countPlayer = PhotonNetwork.CountOfPlayers;
        text = PhotonNetwork.CountOfPlayersOnMaster.ToString();
        text2 = PhotonNetwork.CountOfPlayers.ToString();
        text3 = PhotonNetwork.CountOfRooms.ToString();
        PlayerCount.text = "待機プレイヤー:" + text + "人";
        PlayerCoun2.text = "接続プレイヤー:" + text2 + "人";
        PlayerCoun3.text = "待機ルーム:" + text3 + "室";
    }

    // Update is called once per frame
    void Update()
    {
        if (countPlayerMaster != PhotonNetwork.CountOfPlayersOnMaster || countPlayer != PhotonNetwork.CountOfPlayers|| countRoom != PhotonNetwork.CountOfRooms)
        {
            text = PhotonNetwork.CountOfPlayersOnMaster.ToString();
            text2 = PhotonNetwork.CountOfPlayers.ToString();
            text3 = PhotonNetwork.CountOfRooms.ToString();
            PlayerCount.text = "待機プレイヤー:" + text + "人";
            PlayerCoun2.text = "接続プレイヤー:" + text2 + "人";
            PlayerCoun3.text = "待機ルーム:" + text3 + "室";
            countPlayerMaster = PhotonNetwork.CountOfPlayersOnMaster;
            countPlayer = PhotonNetwork.CountOfPlayers;
            countRoom= PhotonNetwork.CountOfRooms;
        }
    }
}
