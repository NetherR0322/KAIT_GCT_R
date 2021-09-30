using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;

public class GamePlayer : MonoBehaviourPunCallbacks, IPunObservable
{
    // 位置座標
    private Vector2 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector2 screenToWorldPointPosition;

    //スプライトのデータを代入するためのもの
    SpriteRenderer MainSpriteRenderer;

    //スプライト
    public Sprite IdleSprite;   //アイドル状態
    public Sprite HoldSprite;   //つかむ

    public bool isClicked = false; //クリック中フラグ

    //[SerializeField]
    //private TextMeshPro nameLabel = default;
    public Text nameLabel;

    GameObject[] tagObjects;

    public Color SpriteColor;   //色分け用

    float time;

    GameObject mainCamObj;
    Camera cam;
    bool one_id = false;

    bool one = false;
    int id;
    bool once = false;
    // Start is called before the first frame update
    void Start()
    {
        //マウスカーソルを非表示

        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        //ニックネーム
        nameLabel.text = photonView.Owner.NickName;

        tagObjects = GameObject.FindGameObjectsWithTag("Cursor");
        this.gameObject.name = tagObjects.Length.ToString();
        //プレイヤーのID別に色を変更する
        //Invoke("ChangeMouseColor",1.5f);
        //photonView.RPC("RPC_SendColor", RpcTarget.All, LobbyNetwork.id);

    }

    // Update is called once per frame
    void Update()
    {
        if (LobbyNetwork.isPlay == true&&one)
        {
            mainCamObj = GameObject.Find("Main Camera");
            cam = mainCamObj.GetComponent<Camera>();
            one = false;
        }
        else if (LobbyNetwork.isPlay == false&&!one)
        {
            mainCamObj = GameObject.Find("LobbyCamera");
            cam = mainCamObj.GetComponent<Camera>();
            one = true;
        }
        if (Cursor.visible == true && !Goal.flag&& !LimitScript.flag)
        {
            Cursor.visible = false;
            once = false;
        }else if ((Cursor.visible == false && Goal.flag && !once)|| (Cursor.visible == false && LimitScript.flag && !once))
        {
            Cursor.visible = true;
            once = true;
        }else if (Cursor.visible == true && !LobbyNetwork.isPlay)
        {
            Cursor.visible = false;
        }
        time += Time.deltaTime;

        // 自身が生成したオブジェクトだけに移動処理を行う
        if (photonView.IsMine)
        {
            // Vector2でマウス位置座標を取得する
            position = Input.mousePosition;

            // マウス位置座標をスクリーン座標からワールド座標に変換する
            screenToWorldPointPosition = cam.ScreenToWorldPoint(position);

            // ワールド座標に変換されたマウス座標を代入
            this.gameObject.transform.position = screenToWorldPointPosition;

            //マウスがクリックされているかの判定
            if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
                ChangeSpriteState();
            }
            if (Input.GetMouseButtonUp(0))
            {
                isClicked = false;
                ChangeSpriteState();
            }

            if (LobbyNetwork.id >= 0 && !one_id)
            {
               id=LobbyNetwork.id;
                //マウスカーソルの色を変更する
                SendColor(id);
                //ChangeColor(SpriteColor);
                one_id = true;
            }

        }
    }
    //任意の値を定期的に同期させる
    // データを送受信するメソッド
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // 自身側が生成したオブジェクトの場合は
            // クリック中フラグのデータを送信する
            stream.SendNext(isClicked);
            stream.SendNext(id);
            SendColor(id);
        }
        else
        {
            // 他プレイヤー側が生成したオブジェクトの場合は
            // 受信したデータからクリック中フラグを更新する
            isClicked = (bool)stream.ReceiveNext();
            id = (int)stream.ReceiveNext();
            SendColor(id);
            ChangeSpriteState();
        }
    }

    void ChangeSpriteState()
    {
        //マウスの判定でSpriteを変更する
        if (isClicked)
        {
            MainSpriteRenderer.sprite = HoldSprite; //つかむ
        }
        else
        {
            MainSpriteRenderer.sprite = IdleSprite; //アイドル状態
        }
    }
    //プレイヤーのID別に色を変更する
    private void SendColor(int PlayerID)
    {
        switch (PlayerID)
        {
            case 0: //マスタークライアント
                SpriteColor = Color.red;
                break;
            case 1:
                SpriteColor = Color.blue;
                break;
            case 2:
                SpriteColor = Color.green;
                break;
            case 3:
                SpriteColor = Color.yellow;
                break;
            case 4:
                SpriteColor = Color.magenta;
                break;
            case 5:
                SpriteColor = Color.cyan;
                break;
            default:
                break;
        }
        MainSpriteRenderer.color = SpriteColor;
    }
}
