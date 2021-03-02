using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LeaveCurrentMatch : MonoBehaviour
{
    //---ルームから退出するボタン---//
    public void OnClick_LeaveMatch()
    {
        PhotonNetwork.LeaveRoom();  //ルームを出る
        PhotonNetwork.LoadLevel(2); //ロビーシーンに遷移
    }
}