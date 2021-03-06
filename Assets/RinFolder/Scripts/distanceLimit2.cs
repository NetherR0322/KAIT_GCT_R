﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anima2D
{
    public class distanceLimit2 : MonoBehaviour
    {
        //スクリプトをつける場所:tako>bone>body
        public GameObject[] target;//足を入れる配列(0-3が左、4-7が右)
        public GameObject[] loot;//足の根本を入れる配列(0-3が左、4-7が右)
        public float maxDist;//足の長さ(これ以上足が伸びなくなる)
        private Rigidbody2D rb;//Rigidbody2D用の箱
        private float LAllDist;//左足の、体からの距離の総和
        private float RAllDist;//右足の、体からの距離の総和
        private float dist;//距離の一時保管場所
        // Start is called before the first frame update
        void Start()
        {
            rb = this.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //左足4本の体からの距離の合計と
            //右足4本の体からの距離の合計を
            //比べて、距離の合計が短いほうに進ませる

            //LAllDist = 0.0f;//左足の距離の合計
            //RAllDist = 0.0f;//右足の距離の合計
            //forceMove.horizonalForce = 0;//たこのx向きの力を0にする
            rb.constraints = RigidbodyConstraints2D.None;//positionのフリーズを解除
            for (int i = 0; i < target.Length; i++)//足の本数(8本)分ループ
            {
                dist = Mathf.Sqrt(Mathf.Pow(loot[i].transform.position.x - target[i].transform.position.x, 2) + Mathf.Pow(loot[i].transform.position.y - target[i].transform.position.y, 2));//体から足の先端の距離を代入
                if (dist > maxDist)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;//指定の距離よりも足が伸びていたらpositionをフリーズ
                    rb.constraints = RigidbodyConstraints2D.None;//positionのフリーズを解除
                }
                //if (i < 4) LAllDist += dist;//左足ならば左足の合計に加算
                //if (i >= 4) RAllDist += dist;//右足ならば右足の合計に加算
                //Debug.Log(i+":"+dist);
            }
            //float mixDist = LAllDist - RAllDist;//左足の合計と右足の合計の差を求める(符号によって短いほうがわかる)
            //if (mixDist > 0) forceMove.horizonalForce = -1;//総距離が短いほうに移動させるように代入
            //if (mixDist < 0) forceMove.horizonalForce = 1;//これも
            //Debug.Log("L:"+ LAllDist + " R:"+ RAllDist);//一応表示してみる
            transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));
        }

        private void OnDrawGizmos()
        {
            //赤い色で0,0,0から上に1の線を引く
            for (int i = 0; i < target.Length; i++)
            {
                dist = Mathf.Sqrt(Mathf.Pow(loot[i].transform.position.x - target[i].transform.position.x, 2) + Mathf.Pow(loot[i].transform.position.y - target[i].transform.position.y, 2));//体から足の先端の距離を代入
                if (dist > maxDist)
                {
                    Gizmos.color = Color.white;
                }
                else { Gizmos.color = Color.green; }
                Gizmos.DrawLine(loot[i].transform.position, target[i].transform.position);
            }
        }
    }
}