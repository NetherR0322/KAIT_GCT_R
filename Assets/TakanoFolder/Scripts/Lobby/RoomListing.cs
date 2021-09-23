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
    //ルームの状況
    [SerializeField]
    private Text _roomIsPlayText;
    private Text RoomIsPlayText
    {
        get { return _roomIsPlayText; }
    }

    public string RoomName { get; private set; }
    public string IsPlay { get; private set; }
    public bool Updated { get; set; }

    //HP
    private float player;
    private float MaxPlayer;

    bool one = false;
    //ルームの人数を表示する
    [SerializeField]
    private Image _roomPlayerImage;
    private Image RoomPlayerImage
    {
        get { return _roomPlayerImage; }
    }
    //private string RoomPlayer;
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
        MaxPlayer = 5;
        player = 1;
        RoomPlayerImage.fillAmount = player / MaxPlayer;
        RoomIsPlayText.text = "募集中";
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
    public void SetRoomPlayerText(float text)
    {
        /*RoomPlayer = text + "/6 ";
        RoomPlayerText.text = RoomPlayer;*/
        player = text;
        RoomPlayerImage.fillAmount = player/MaxPlayer;
    }
    public void SetRoomIsPlay(bool text)
    {
        if (text==false)
        {
            RoomIsPlayText.text = "プレイ中";
        }
    }
}