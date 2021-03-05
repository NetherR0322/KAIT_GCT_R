using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    float Times;
    
    private Vector3 targetps;

    public float speed = -0.01f;

    //float Xsize= 1.494188f;
    //float Ysize= 1.494188f;

    void Start()
    {
        targetps = transform.position;      


    }

    // Update is called once per frame
    void Update()
    {
       Times = Time.time+10;
        targetps.x=targetps.x + speed;
        transform.position = new Vector3(targetps.x, targetps.y, targetps.z);
        
    }

       void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Return")
        {
            Transform cl = gameObject.transform;//トランスフォーム(位置とか大きさ)を取得してます
            cl.transform.localScale = new Vector2(cl.localScale.x* -1,cl.localScale.y) ;//ここでスケールを変更することで反転させてます

            speed = speed * -1;//逆方向に進む


            //---ここから下書き換えさせてもらいました---//

            //Vector3 crow = new Vector3(Xsize, Ysize, 1);　//カラスの大きさを取得してる
            //crow.x = crow.x * -1; //xに-1をかけることで反転
            //Xsize = Xsize * -1;   //xsizeに-1をかけることで反転
            //gameObject.transform.localScale = crow;//変更

            //画像の向きが決まってないと変わってくれないので変更しました。
        }
    }
}
