﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbySelect : MonoBehaviourPunCallbacks
{
    //public GameObject CreateRoomLobby;
    //public GameObject SearchRoomLobby;
    // Start is called before the first frame update
    GameObject PlayerNetWork;
    private PhotonView PhotonView;
    public Image BgImg, CloseImg, CrImage, SrImage, BaImage;
    public Text text;
    public Button CrButtom, SrButtom;
    public BoxCollider2D CrCol, SrCol,CloseCol;
    void Start()
    {
        PlayerNetWork = GameObject.Find("PlayerNetWork");
        PhotonView = PlayerNetWork.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void On_click_CreateRoomLobby()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        //SearchRoomLobby.SetActive(false);
        //CreateRoomLobby.SetActive(true);
        //this.gameObject.SetActive(false);
        PhotonNetwork.JoinRandomRoom();
    }
    public void On_click_SearchRoomLobby()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        //CreateRoomLobby.SetActive(false);
        //SearchRoomLobby.SetActive(true);
        //this.gameObject.SetActive(false);
        BgImg.enabled = false; 
        CloseImg.enabled = false; 
        CrImage.enabled = false; 
        SrImage.enabled = false; 
        BaImage.enabled = false;
        text.enabled = false;
        CrButtom.enabled = false; 
        SrButtom.enabled = false;
        CrCol.enabled = false; 
        SrCol.enabled = false;
        CloseCol.enabled = false;
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        BGMPlayer.GetInstance().PlaySound(0);
        //ルームの設定：公開,入室可,最大8人
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };

        //新しいルームを作ります
        //ルームネームが入力されているかどうか判定
        PhotonNetwork.CreateRoom(Random.Range(0, 99) + "号室", roomOptions, TypedLobby.Default);

        PlayerNetwork.stageNumber = 5;
        CurrentRoomCanvas.num = 5;
    }
}
