using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overActive : MonoBehaviour
{
    //スクリプトをつける場所:各IK
    public float curSize;//カーソルの判定サイズ
    // Start is called before the first frame update
    void Start()
    {
        //ないよ
    }

    // Update is called once per frame
    void Update()
    {
        var targetPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);// マウスの位置を取得して…
        float dist = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - targetPos.x, 2) + Mathf.Pow(transform.position.y - targetPos.y, 2));//

        if (dist<= curSize) this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        if (dist > curSize) this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }
}
