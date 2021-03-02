using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerNetwork : MonoBehaviour
{
    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }  //LobbyNetworkに渡す

    private PhotonView PhotonView;

    private int PlayersInGame = 0; //プレイヤーの人数

    public TMP_InputField inputField;
    public TextMeshProUGUI text;

    private void Awake()
    {
        Instance = this;
        PhotonView = GetComponent<PhotonView>();

        //シーン切り替えを検出
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        
        //名前入力用
        inputField = inputField.GetComponent<TMP_InputField>();

    }
    public void OnClicked_InputName()
    {
        //テキストにinputFieldの内容を反映
        text.text = inputField.text;

        //名前入力されているか判定
        if (string.IsNullOrWhiteSpace(inputField.text) && string.IsNullOrWhiteSpace(inputField.text))
        {
            //プレイヤーの名前を自動で生成
            PlayerName = "Player(" + Random.Range(1000, 9999) + ")";

            PhotonNetwork.LoadLevel(2);
        }
        else
        {
            //プレイヤーの名前を自動で生成
            PlayerName = inputField.text;

            PhotonNetwork.LoadLevel(2);
        }

    }
    /*public void OnClicked_LoadMovie()
    {
        PhotonView.RPC("LoadMovieScene", RpcTarget.All);
    }*/

    //---プレイヤースポーン関係---//
    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        PlayersInGame = 0;　//初期化

        //ステージ1
        if (scene.buildIndex == 5)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                MasterLoadedGame();
            }
            else
            {
                NonMasterLoadedGame();
            }
        }
        //ステージ2
        if (scene.buildIndex == 6)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                MasterLoadedGame2();
            }
            else
            {
                NonMasterLoadedGame();
            }
        }

    }
    //ステージ1
    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", RpcTarget.Others);
    }
    //ステージ2
    private void MasterLoadedGame2()
    {
        PhotonView.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers2", RpcTarget.Others);
    }
    private void NonMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(5);
    }

    [PunRPC]
    private void RPC_LoadGameOthers2()
    {
        PhotonNetwork.LoadLevel(6);
    }

    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        PlayersInGame++;
        if (PlayersInGame == PhotonNetwork.PlayerList.Length)
        {
            print("プレイヤー全員が遷移しました");
            PhotonView.RPC("RPC_CreatePlayer", RpcTarget.All);
        }
    }
    [PunRPC]
    private void RPC_CreatePlayer()
    {
        //マウスカーソルを生成
        float randomValue = Random.Range(5f, 5f);
        PhotonNetwork.Instantiate("GamePlayer", Vector3.up * randomValue, Quaternion.identity, 0);
    }
    [PunRPC]
    private void LoadMovieScene()
    {
        SceneManager.LoadSceneAsync("MoveiScene", LoadSceneMode.Additive);
    }
}
