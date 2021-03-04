using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

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

    [SerializeField]
    private TextMeshPro nameLabel = default;

    GameObject[] tagObjects;

    public Color SpriteColor;   //色分け用

    float time;

    GameObject mainCamObj;
    Camera cam;

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

        mainCamObj = GameObject.Find("Main Camera");
        cam = mainCamObj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
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
            if (Input.GetMouseButton(0))
            {
                isClicked = true;
            }
            else
            {
                isClicked = false;
            }
            //Spriteを変更する
            ChangeSpriteState();

            if (time <= 5f)
            {
                //マウスカーソルの色を変更する
                ChangeMouseColor();
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
        }
        else
        {
            // 他プレイヤー側が生成したオブジェクトの場合は
            // 受信したデータからクリック中フラグを更新する
            isClicked = (bool)stream.ReceiveNext();
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
    void ChangeMouseColor()
    {
        photonView.RPC("RPC_SendColor", RpcTarget.All, LobbyNetwork.id);
    }

    //プレイヤーのID別に色を変更する
    [PunRPC]
    private void RPC_SendColor(int PlayerID)
    {
        switch (PlayerID)
        {
            case 1: //マスタークライアント
                SpriteColor = Color.red; 
                break;
            case 2:
                SpriteColor = Color.blue;
                break;
            case 3:
                SpriteColor = Color.green;
                break;
            case 4:
                SpriteColor = Color.yellow;
                break;
            case 5:
                SpriteColor = Color.magenta;
                break;
            case 6:
                SpriteColor = Color.cyan;
                break;
            default:
                break;
        }
        MainSpriteRenderer.color = SpriteColor;
    }
}
