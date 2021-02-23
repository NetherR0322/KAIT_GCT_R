using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CurrentRoomCanvas : MonoBehaviour
{
    public GameObject stage;    //ステージ画面

    //int num = 2;

    //---ゲームプレイシーンに遷移するボタン---//
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

        PhotonNetwork.LoadLevel(3); //ゲームプレイシーンに遷移
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
        //num = 2;
    }
    //ステージ2
    public void OnClick_Stage2()
    {
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        //num = 3;
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
