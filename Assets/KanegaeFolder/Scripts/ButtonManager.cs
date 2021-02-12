using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ButtonManager : MonoBehaviour
{
    
    void Start()
    {
        Cursor.visible = true;
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
        GameObject DDOobj = GameObject.FindGameObjectWithTag("DDO");
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();  //ルームを出る
        PhotonNetwork.Disconnect();
        Destroy(DDOobj);
        SceneManager.LoadScene(0);//タイトルシーンに遷移
    }

    public void GoGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}


