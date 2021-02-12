using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LeaveLobby : MonoBehaviour
{
    //---ロビーから退出するボタン---//
    public void OnClick_LeaveLobby()
    {
        PhotonNetwork.LeaveLobby();  //ルームを出る
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0); //タイトルシーンに遷移
    }
}
