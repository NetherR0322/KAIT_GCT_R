using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ButtonManager : MonoBehaviour
{
    GameObject PlayerNetWork;
    private PhotonView PhotonView;
    void Start()
    {
        Cursor.visible = true;
        PlayerNetWork = GameObject.Find("PlayerNetWork");
        PhotonView = PlayerNetWork.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoLobby()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        SceneManager.LoadScene("LobbyScene");
    }

    public void GoMapChoose()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        SceneManager.LoadScene("MapChooseScene");
    }

    public void ReturnGame()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        GameObject Pose = GameObject.Find("Canvas");
        KanegaeGameManager.OnPose = false;
        Pose.SetActive(false);
    }

    public void GoTitle()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        Cursor.visible = true;
        GameObject DDOobj = GameObject.FindGameObjectWithTag("DDO");
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();  //ルームを出る
        PhotonNetwork.Disconnect();
        Destroy(DDOobj);
        SceneManager.LoadScene(0);//タイトルシーンに遷移
    }
    public void retrunLobby()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonView.RPC("closeRoom", RpcTarget.All);
        }
        else
        {
            Cursor.visible = true;
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene(2);
        }
    }
    public void GoRoom()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        LobbyNetwork.isPlay = false;
        PhotonView.RPC("UnLoadStageScene", RpcTarget.All);
    }
    public void GoRoom2()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        LobbyNetwork.isPlay = false;
        PhotonView.RPC("UnLoadStageScene2", RpcTarget.All);
    }
    public void GoGame()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        SceneManager.LoadScene("GameScene");
    }
}


