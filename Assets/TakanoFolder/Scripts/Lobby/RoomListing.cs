using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    //ルームの名前を表示する
    [SerializeField]
    private Text _roomNameText;
    private Text RoomNameText
    {
        get { return _roomNameText; }
    }
    //ルームの人数を表示する
    [SerializeField]
    private Text _roomPlayerText;
    private Text RoomPlayerText
    {
        get { return _roomPlayerText; }
    }

    public string RoomName { get; private set; }

    public bool Updated { get; set; }

    private string RoomPlayer;
    private void Start()
    {
        //LobbyCanvasを読み込む
        GameObject lobbyCanvasObj = MainCanvasManager.Instance.LobbyCanvas.gameObject;

        //ロビーが破壊されたときにアクセスできないようにする
        if (lobbyCanvasObj == null)
            return;

        //ボタンを参照
        LobbyCanvas lobbyCanvas = lobbyCanvasObj.GetComponent<LobbyCanvas>();

        Button button = GetComponent<Button>();
        //ルームに入る
        button.onClick.AddListener(() => lobbyCanvas.OnClickJoinRoom(RoomNameText.text));

    }

    //RoomListingが破壊されたとき
    private void OnDestroy()
    {
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
    }

    //ルームの名前を設定する
    public void SetRoomNameText(string text)
    {
        RoomName = text;
        RoomNameText.text = RoomName;
    }

    //ルームの人数を設定する
    public void SetRoomPlayerText(string text)
    {
        RoomPlayer = text + "/6 ";
        RoomPlayerText.text = RoomPlayer;
    }
}