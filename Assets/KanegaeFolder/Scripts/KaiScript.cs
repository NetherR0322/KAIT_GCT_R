﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaiScript : MonoBehaviour
{
    GameObject[] tagObjects;

    public GameObject Kai_UI;

    public static int rate;

    public int M_rate = 0;

    public Text Ratetext;

    // Start is called before the first frame update
    void Start()
    {
        Check("Kai");
        M_rate = tagObjects.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Check("Kai");

        Ratetext.text = rate + "/" + M_rate;

        if(tagObjects.Length <= 0)
        {
            Kai_UI.gameObject.SetActive(false);
        }
    }

    void Check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        //Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数
        if (tagObjects.Length == 0)
        {
           // Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }

    }
}