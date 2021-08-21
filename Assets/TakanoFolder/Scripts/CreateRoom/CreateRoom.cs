using System.Collections;
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
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 3 };

        //新しいルームを作ります
        //ルームネームが入力されているかどうか判定
        if (string.IsNullOrWhiteSpace(RoomName.text) && string.IsNullOrWhiteSpace(RoomName.text))
        {
            print("ルームの作成に失敗");
        }
        else
        {
            if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
            {
                print("ルームの作成に成功");
            }
        }
        PlayerNetwork.stageNumber = 5;
        CurrentRoomCanvas.num = 5;
    }
}