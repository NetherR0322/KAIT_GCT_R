using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CurrentRoomCanvas : MonoBehaviour
{
    public GameObject stage;    //ステージ画面

    public static int num = 5; //stage num

    GameObject PlayerNetWork;
    private PhotonView PhotonView;

    //---ゲームプレイシーンに遷移するボタン---//
    private void Awake()
    {
        PlayerNetWork = GameObject.Find("PlayerNetWork");
        PhotonView = PlayerNetWork.GetComponent<PhotonView>();
    }
    public void OnClick_Start()
    {
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        //プレイ中のルームを非表示にし、後から入れないようにする
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonView.RPC("LoadMovieScene", RpcTarget.All);
        //PhotonNetwork.LoadLevel(num); //ゲームプレイシーンに遷移
    }

    //ステージ画面
    public void OnClick_StageSelect()
    {
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        stage.SetActive(true);

    }
    //ステージ1
    public void OnClick_Stage1()
    {
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        num = 5; //stage1
    }
    //ステージ2
    public void OnClick_Stage2()
    {
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        num = 6; //stage2
    }
    //ルームに戻る
    public void OnClick_returnRoom()
    {
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        stage.SetActive(false);
    }
}
