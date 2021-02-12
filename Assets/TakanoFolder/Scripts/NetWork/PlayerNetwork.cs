using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour
{
    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }  //LobbyNetworkに渡す

    private PhotonView PhotonView;

    private int PlayersInGame = 0; //プレイヤーの人数

    private void Awake()
    {
        Instance = this;
        PhotonView = GetComponent<PhotonView>();

        //プレイヤーの名前を自動で生成
        PlayerName = "Player" + Random.Range(1000, 9999);

        SceneManager.sceneLoaded += OnSceneFinishedLoading;

        //ロビーシーンに遷移
        PhotonNetwork.LoadLevel(2);
    }
    //---プレイヤースポーン関係---//
    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        PlayersInGame = 0;
        if (scene.name == "RinScene")
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

    }
    private void MasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
        PhotonView.RPC("RPC_LoadGameOthers", RpcTarget.Others);
    }
    private void NonMasterLoadedGame()
    {
        PhotonView.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(3);
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
        PhotonNetwork.Instantiate(Path.Combine("GamaPlayer"), Vector3.up * randomValue, Quaternion.identity, 0);
    }
}
