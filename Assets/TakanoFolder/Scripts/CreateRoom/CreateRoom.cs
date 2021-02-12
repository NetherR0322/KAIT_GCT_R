﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    //ルームの名前を入力するところ
    [SerializeField]
    private Text _roomName;
    private Text RoomName
    {
        get { return _roomName; }
    }

    //---ルームを作るボタンを押したとき---//
    public void OnClicked_CreateRoom()
    {
        //ルームの設定：公開,入室可,最大8人
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 8 };

        //新しいルームを作ります
        if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
        {
            print("ルームの作成に成功");
        }
        else
        {
            print("ルームの作成に失敗");
        }
    }
    /*
    //---CreateRoomの呼び出しを確認する---//

    //ルームの作成に失敗したとき
    public void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        print("create room failed"+codeAndMessage);
    }
    //ルームの作成に成功したとき
    public override void OnCreatedRoom()
    {
        Debug.Log("作成したルームを確認");
    }*/
}