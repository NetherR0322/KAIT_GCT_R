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

        //プレイヤーの名前を自動で生成
        PlayerName = "Player" + Random.Range(1000, 9999);

        SceneManager.sceneLoaded += OnSceneFinishedLoading;

        inputField = inputField.GetComponent<TMP_InputField>();

    }
    public void OnClicked_InputName()
    {
        //テキストにinputFieldの内容を反映
        text.text = inputField.text;

        //プレイシーンに遷移
        if (string.IsNullOrWhiteSpace(inputField.text) && string.IsNullOrWhiteSpace(inputField.text))
        {
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

    //---プレイヤースポーン関係---//
    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        PlayersInGame = 0;
        if (scene.name == "Shopping streetStage")
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
        if (scene.name == "AquariumScene")
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
    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", RpcTarget.Others);
    }
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
        PhotonNetwork.LoadLevel(4);
    }

    [PunRPC]
    private void RPC_LoadGameOthers2()
    {
        PhotonNetwork.LoadLevel(5);
    }

    [PunRPC]
    private void RPC_LoadedGameScene()
    {
        PlayersInGame++;
        if (PlayersInGame == PhotonNetwork.PlayerList.Length)
        {
            print("ALL PLAYER ARE IN THE GAME SCENE");
            PhotonView.RPC("RPC_CreatePlayer", RpcTarget.All);
        }
    }
    [PunRPC]
    private void RPC_CreatePlayer()
    {
        float randomValue = Random.Range(5f, 5f);
        PhotonNetwork.Instantiate("GamePlayer", Vector3.up * randomValue, Quaternion.identity, 0);
    }
}
