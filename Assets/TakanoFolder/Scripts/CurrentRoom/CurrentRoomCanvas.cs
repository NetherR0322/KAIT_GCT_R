using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CurrentRoomCanvas : MonoBehaviour
{
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
        //PhotonNetwork.CurrentRoom.IsVisible = false;

        PhotonNetwork.LoadLevel(3); //ゲームプレイシーンに遷移
    }
}
