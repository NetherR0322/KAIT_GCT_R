using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    public int rin_curHaveId;
    //スクリプトをつける場所:カーソル
    // Start is called before the first frame update
    void Start()
    {
        //ないよ
    }

    // Update is called once per frame
    void Update()
    {
        var targetPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);// マウスの位置を取得して…
        targetPos.z = 0;//zがカメラ位置のままだから0にして…
        this.transform.position = targetPos;//カーソルをマウス位置に持っていく
        Debug.Log(rin_curHaveId);
    }
}
