using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;

public class TrainMove : MonoBehaviourPunCallbacks {
    // Start is called before the first frame update
    GameObject barrierrod;
    BarrierRodScript barrierRod;
    Transform myTransform;
    Vector3 defaultpos;
    public static bool flag = false;
    public float speed =-1.0f;

    public bool goScene;
    void Start()
    {
        myTransform = this.transform;
        barrierrod = GameObject.Find("BarrierRod");
        // 座標を取得
        defaultpos = myTransform.position;
        defaultpos.x += 0.01f;    // x座標へ0.01加算

        myTransform.position = defaultpos;  // 座標を設定   
    }

    // Update is called once per frame
    void Update()
    {
        barrierRod = barrierrod.GetComponent<BarrierRodScript>();
        if (barrierRod.state == 0 || barrierRod.state == 1)
        {
            this.gameObject.transform.Translate(speed, 0, 0);
        }
        if (barrierRod.state == 2)
        {
            myTransform.position = defaultpos;
        }
        if (goScene) SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
    }
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "tako")
        {
            if (flag == false)
            {
                Debug.Log("電車と衝突!!!");
                //SceneManager.LoadScene("GameOverScene");
                GetComponent<PhotonView>().RPC(nameof(IsHit), RpcTarget.All, true);
                //SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
                flag = true;
                goScene = true;
            }
        }
    }

    [PunRPC]
    private void IsHit(bool boo)
    {
        Debug.Log("PUN!!!");
        //SceneManager.LoadScene("GameOverScene");
        //SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
        flag = true;
        goScene=boo;
    }
}
