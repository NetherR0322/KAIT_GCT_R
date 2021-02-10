using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceMove : MonoBehaviour
{
    //スクリプトをつける場所:tako>bone>body
    private Rigidbody2D rb;//Rigidbody2D用の箱
    public Vector2 vec;//進めるとき(どの足も上限の長さまで伸びていないとき)に進む速度
    private Vector2 defaultVec;//↑を保存しておく変数
    public static float horizonalForce;//横に進むときにこの中身を見て進む(外部のスクリプトで進行方向によって値が代入される)
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        defaultVec = vec;//初期進行速度を保存
    }

    // Update is called once per frame
    void Update()
    {
        vec = defaultVec;//初期化
        vec.x += horizonalForce;//横向きの力を加える
        rb.AddForce(vec);//publicで指定した方向に力を加える
        this.transform.rotation = Quaternion.Euler(0,0,180);//たこの角度を固定(フリーズが効かない)
    }
}
