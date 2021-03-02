using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MainCanvasManager : MonoBehaviour
{
    //---ロビーキャンバスとルームキャンバスを管理---//

    public static MainCanvasManager Instance;
    GameObject PlayerNetWork;
    private PhotonView PhotonView;
    //GameObject Movie;
    //private PlayableDirector playableDirector;

    //ロビーキャンバス(ルーム作ったりするやつ)
    [SerializeField]
    private LobbyCanvas _lobbyCanvas;
    public LobbyCanvas LobbyCanvas
    {
        get { return _lobbyCanvas; }
    }

    //ルームキャンバス(ルームからゲームを開始したりするやつ)
    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas
    {
        get { return _currentRoomCanvas; }
    }

    private void Awake()
    {
        Instance = this;

        //PlayerNetWork = GameObject.Find("PlayerNetWork");
        //PhotonView = PlayerNetWork.GetComponent<PhotonView>();
    }
    private void Update()
    {
        //Movie = GameObject.Find("TakoMovies");
        //playableDirector = Movie.GetComponent<PlayableDirector>();
        /*if (playableDirector.state != PlayState.Playing)
        {
            Debug.Log("終了");
            PhotonNetwork.LoadLevel(CurrentRoomCanvas.num);
        }*/
    }

    /*public void OnClicked_LoadMovie()
    {
        PhotonView.RPC("LoadMovieScene", RpcTarget.All);
    }*/
}
