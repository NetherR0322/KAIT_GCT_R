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
        SceneManager.LoadScene("LobbyScene");
    }

    public void GoMapChoose()
    {
        SceneManager.LoadScene("MapChooseScene");
    }

    public void ReturnGame()
    {
        GameObject Pose = GameObject.Find("Canvas");
        KanegaeGameManager.OnPose = false;
        Pose.SetActive(false);
    }

    public void GoTitle()
    {
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
        Cursor.visible = true;
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(2);//タイトルシーンに遷移
    }
    public void GoRoom()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        LobbyNetwork.isPlay = false;
        PhotonView.RPC("UnLoadStageScene", RpcTarget.All);
    }
    public void GoRoom2()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        LobbyNetwork.isPlay = false;
        PhotonView.RPC("UnLoadStageScene2", RpcTarget.All);
    }
    public void GoGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}


