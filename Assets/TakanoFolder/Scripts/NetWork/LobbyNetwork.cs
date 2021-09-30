using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun.UtilityScripts;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    //プレイヤーのID
    public static int id;
    public GameObject LobbyCanvas;
    public GameObject StartButton;
    public GameObject returnButton;
    public GameObject LobbyCamera;
    public static bool isPlay=false;
    private void Start()
    {
        //サーバーに接続しているか確認する
        if (!PhotonNetwork.IsConnected)
        {
            print("サーバーに接続しています");
            PhotonNetwork.ConnectUsingSettings();
        }
        Cursor.visible = true;
        isPlay = false;
    }
    private void Update()
    {
        if (isPlay==true)
        {
            //LobbyCanvas.SetActive(false);
            StartButton.SetActive(false);
            returnButton.SetActive(false);
            LobbyCamera.SetActive(false);
        }
        else if (isPlay==false)
        {
            //LobbyCanvas.SetActive(true);
            StartButton.SetActive(true);
            returnButton.SetActive(true);
            LobbyCamera.SetActive(true);
        }
    }

    //---マスターサーバーに接続した時---//
    public override void OnConnectedToMaster()
    {
        print("マスターに接続しています");
        PhotonNetwork.AutomaticallySyncScene = false;   // シーンの自動同期を無効にする

        PhotonNetwork.NickName = PlayerNetwork.Instance.PlayerName;　//名前を同期

        PhotonNetwork.JoinLobby(TypedLobby.Default);    //有効なRoomの一覧を得る
    }

    //---ロビーに接続した時---//
    public override void OnJoinedLobby()
    {
        print("ロビーに接続しています");
        Cursor.visible = true;
        //ルームに接続しているか確認する
        if (!PhotonNetwork.InRoom)
        {
            //LobbyCanvasを上に配置
            MainCanvasManager.Instance.LobbyCanvas.transform.SetAsLastSibling();
        }
    }
    //ルームに入室した時
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("GamePlayer", new Vector2(0f, 0f), Quaternion.identity, 0);
        //プレイヤーのidを取得
        //Photon.Realtime.Player player = PhotonNetwork.LocalPlayer;
        //id = player.ActorNumber;
    }
    public override void OnEnable()
    {
        base.OnEnable();
        PlayerNumbering.OnPlayerNumberingChanged += OnPlayerNumberingChanged;

    }
    public override void OnDisable()
    {
        base.OnDisable();
        PlayerNumbering.OnPlayerNumberingChanged -= OnPlayerNumberingChanged;
    }
    private void OnPlayerNumberingChanged()
    {
        Debug.Log("ON Player Numbering changed");
        Photon.Realtime.Player player = PhotonNetwork.LocalPlayer;
        id = player.GetPlayerNumber();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("でれたよ");
    }
}
