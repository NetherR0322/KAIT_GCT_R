﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GageScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;

    private float dist = 0f;

    public GameObject GageTako;

    void Start()
    {
        //   dist = Kyorihakaru.dis;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(GageTako.transform.localPosition.y);

        if (dist!= Kyorihakaru.dis)
        {
            if (dist > Kyorihakaru.dis)
            {
                GageTako.transform.localPosition = new Vector3(GageTako.transform.localPosition.x, GageTako.transform.localPosition.y + speed, GageTako.transform.localPosition.z);
                dist = Kyorihakaru.dis;
            }
            else
            {
                GageTako.transform.localPosition = new Vector3(GageTako.transform.localPosition.x, GageTako.transform.localPosition.y - speed, GageTako.transform.localPosition.z);
                dist = Kyorihakaru.dis;
            }
        }

    }
}