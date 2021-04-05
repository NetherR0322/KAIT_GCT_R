using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class key : MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject asi_top_obj;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //左ボタンが押されている間、接触している足の座標をトレースする
        if (flag == true && Input.GetMouseButton(0))
        {
            Vector3 pos = asi_top_obj.transform.position;

            this.transform.position = pos;
        }
        //左ボタンが離されたとき足の座標のトレースをやめる
        if (Input.GetMouseButtonUp(0))
        {
            flag = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //すでに接触しているか判別
        if (flag == false)
        {
            //接触した足の判別
            switch (collision.gameObject.name)
            {
                case "L1IK":
                    asi_top_obj = GameObject.Find("L1IK");
                    flag = true;
                    break;
                case "L2IK":
                    asi_top_obj = GameObject.Find("L2IK");
                    flag = true;
                    break;
                case "L3IK":
                    asi_top_obj = GameObject.Find("L3IK");
                    flag = true;
                    break;
                case "L4IK":
                    asi_top_obj = GameObject.Find("L4IK");
                    flag = true;
                    break;
                case "R1IK":
                    asi_top_obj = GameObject.Find("R1IK");
                    flag = true;
                    break;
                case "R2IK":
                    asi_top_obj = GameObject.Find("R2IK");
                    flag = true;
                    break;
                case "R3IK":
                    asi_top_obj = GameObject.Find("R3IK");
                    flag = true;
                    break;
                case "R4IK":
                    asi_top_obj = GameObject.Find("R4IK");
                    flag = true;
                    break;
                default:
                    break;
            }
        }
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
