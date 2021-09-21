using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CurrentRoomCanvas : MonoBehaviour
{
    public GameObject stage;    //ステージ画面

    public static int num = 5; //stage num

    GameObject PlayerNetWork;
    private PhotonView PhotonView;

    //public Text stageName;
    public Text stageName2;

    //---ゲームプレイシーンに遷移するボタン---//
    private void Awake()
    {
        PlayerNetWork = GameObject.Find("PlayerNetWork");
        PhotonView = PlayerNetWork.GetComponent<PhotonView>();
    }
    public void OnClick_Start()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        //プレイ中のルームを非表示にし、後から入れないようにする
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        //ムービーシーンを読み込む
        PhotonView.RPC("LoadMovieScene", RpcTarget.All);
        PhotonView.RPC("isPlay", RpcTarget.All);
    }

    //ステージ画面
    public void OnClick_StageSelect()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        stage.SetActive(true);
        if (num == 5)
        {
            stageName2.text = "選択中のステージ:商店街";
        }
    }
    //ステージ1
    public void OnClick_Stage1()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        num = 5; //stage1
        PhotonView.RPC("StageNumber", RpcTarget.All, num);
        stageName2.text = "選択中のステージ:商店街";
    }
    //ステージ2
    public void OnClick_Stage2()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        num = 6; //stage2
        PhotonView.RPC("StageNumber", RpcTarget.All, num);
        stageName2.text = "選択中のステージ:水族館";
    }
    //ルームに戻る
    public void OnClick_returnRoom()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        stage.SetActive(false);
    }
}
