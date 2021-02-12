using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour
{
    //---ロビーキャンバスとルームキャンバスを管理---//

    public static MainCanvasManager Instance;

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
    }
}
