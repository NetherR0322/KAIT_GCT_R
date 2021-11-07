using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class TrainMove : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject barrierrod;
    BarrierRodScript barrierRod;
    Transform myTransform;
    Vector3 defaultpos;
    public static bool flag = false;
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
            this.gameObject.transform.Translate(-0.6f, 0, 0);
        }
        if (barrierRod.state == 2)
        {
            myTransform.position = defaultpos;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "tako")
        {
            if (flag == false)
            {
                //Cursor.visible = true;
                SceneManager.LoadSceneAsync("GameOverScene", LoadSceneMode.Additive);
                flag = true;

            }
        }
    }
}
