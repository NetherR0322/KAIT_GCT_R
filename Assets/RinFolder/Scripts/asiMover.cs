using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asiMover : MonoBehaviour
{
    //スクリプトをつける場所:各IK
    //Event Triggerにそれぞれ入れる
    //Pointer DownにtouchDown
    //Pointer UpにtouchUp
    //private bool isHave;//プレイヤーに足をつかまれている状態か
    public GameObject dPos;//IKが遠くに行き過ぎたときの初期位置(足先にからのGOをつけておく)
    public float touchDist;
    public static string isHave;
    // Start is called before the first frame update
    void Start()
    {
        //ないよ
    }

    // Update is called once per frame
    void Update(){
        //Debug.Log(this.name+":"+isHave);
        Vector2 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウスの位置を取得して…
        float dist = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - mp.x, 2) + Mathf.Pow(transform.position.y - mp.y, 2));//
        if (dist<=touchDist&&Input.GetMouseButton(0)&&(isHave==this.name||isHave==""))//もし足をつかまれていたら
        {
            this.transform.position = mp;//IKの位置をカーソルの位置に持っていく
            isHave = this.name;

        }
        if (Input.GetMouseButtonUp(0)) isHave = "";
   }
    /*
    public void touchDown() {//足をクリック
        isHave = true;
        Debug.Log("Down");
    }
    public void touchUp(){//足を離す
        isHave = false;
        this.transform.position = dPos.transform.position;//遠くに行き過ぎたIKを戻す
        Debug.Log("Up");
    }
    */
}
