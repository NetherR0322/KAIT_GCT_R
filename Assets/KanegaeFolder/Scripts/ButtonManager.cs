using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

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
        if (!PhotonNetwork.IsMasterClient)
        {
            LobbyNetwork.isPlay = false;
            PhotonNetwork.LeaveRoom();
        }
        PhotonView.RPC("UnLoadStageScene", RpcTarget.All);
        PhotonView.RPC("Gotitle_Master", RpcTarget.All);
    }
    public void GoTitle2()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        if (!PhotonNetwork.IsMasterClient)
        {
            LobbyNetwork.isPlay = false;
            PhotonNetwork.LeaveRoom();
        }
        PhotonView.RPC("UnLoadStageScene2", RpcTarget.All);

        PhotonView.RPC("Gotitle_Master", RpcTarget.All);
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
        //LobbyNetwork.isPlay = false;
        PhotonNetwork.CurrentRoom.IsOpen = true;
        PhotonView.RPC("UnLoadStageScene", RpcTarget.All);
    }
    public void GoRoom2()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        //LobbyNetwork.isPlay = false;
        PhotonNetwork.CurrentRoom.IsOpen = true;
        PhotonView.RPC("UnLoadStageScene2", RpcTarget.All);
    }
    public void GoGame()
    {
        BGMPlayer.GetInstance().PlaySound(0);
        SceneManager.LoadScene("GameScene");
    }
}


