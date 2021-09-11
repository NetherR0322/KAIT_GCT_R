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
    int countPlayerMaster;
    int countPlayer;
    // Start is called before the first frame update
    void Start()
    {
        countPlayerMaster = PhotonNetwork.CountOfPlayersOnMaster;
        countPlayer = PhotonNetwork.CountOfPlayers;
        text = PhotonNetwork.CountOfPlayersOnMaster.ToString();
        text2 = PhotonNetwork.CountOfPlayers.ToString();
        PlayerCount.text = "待機プレイヤー:" + text + "人";
        PlayerCoun2.text = "接続プレイヤー:" + text2 + "人";
    }

    // Update is called once per frame
    void Update()
    {
        if (countPlayerMaster!= PhotonNetwork.CountOfPlayersOnMaster|| countPlayer != PhotonNetwork.CountOfPlayers)
        {
            text = PhotonNetwork.CountOfPlayersOnMaster.ToString();
            text2 = PhotonNetwork.CountOfPlayers.ToString();
            PlayerCount.text = "待機プレイヤー:" + text + "人";
            PlayerCoun2.text = "接続プレイヤー:" + text2 + "人";
            countPlayerMaster = PhotonNetwork.CountOfPlayersOnMaster;
            countPlayer = PhotonNetwork.CountOfPlayers;
        }
    }
}
