﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    //プレイヤーのID
    public static int id;
    public GameObject LobbyCanvas;
    public static bool isPlay=false;
    private void Start()
    {
        //サーバーに接続しているか確認する
        if (!PhotonNetwork.IsConnected)
        {
            print("サーバーに接続しています");
            PhotonNetwork.ConnectUsingSettings();
        }
        Cursor.visible = true;
        isPlay = false;
    }
    private void Update()
    {
        if (isPlay==true)
        {
            LobbyCanvas.SetActive(false);
        }
        else if (isPlay==false)
        {
            LobbyCanvas.SetActive(true);
        }
    }

    //---マスターサーバーに接続した時---//
    public override void OnConnectedToMaster()
    {
        print("マスターに接続しています");
        PhotonNetwork.AutomaticallySyncScene = false;   // シーンの自動同期を無効にする

        PhotonNetwork.NickName = PlayerNetwork.Instance.PlayerName;　//名前を同期

        PhotonNetwork.JoinLobby(TypedLobby.Default);    //有効なRoomの一覧を得る
    }

    //---ロビーに接続した時---//
    public override void OnJoinedLobby()
    {
        print("ロビーに接続しています");

        //ルームに接続しているか確認する
        if (!PhotonNetwork.InRoom)
        {
            //LobbyCanvasを上に配置
            MainCanvasManager.Instance.LobbyCanvas.transform.SetAsLastSibling();
        }
    }
    //ルームに入室した時
    public override void OnJoinedRoom()
    {
        //プレイヤーのidを取得
        Photon.Realtime.Player player = PhotonNetwork.LocalPlayer;
        id = player.ActorNumber;
    }
}
