using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class TimeLineManager : MonoBehaviour
{
    private PlayableDirector playableDirector;

    GameObject PlayerNetWork;
    private PhotonView PhotonView;


    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();

        PlayerNetWork = GameObject.Find("PlayerNetWork");
        PhotonView = PlayerNetWork.GetComponent<PhotonView>();

        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playableDirector.state != PlayState.Playing&&flag==false)
        {
            //PhotonNetwork.LoadLevel(CurrentRoomCanvas.num);
            PhotonView.RPC("LoadStageScene", RpcTarget.All);
            PhotonView.RPC("UnLoadMovieScene", RpcTarget.All);
            flag = true;
        }
    }
    public void On_clickedSkip()
    {
        //マスタークライアント(ルームの主)だけが押せるボタン
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        //PhotonNetwork.LoadLevel(CurrentRoomCanvas.num);
        PhotonView.RPC("LoadStageScene", RpcTarget.All);
        PhotonView.RPC("UnLoadMovieScene", RpcTarget.All);
    }
}
