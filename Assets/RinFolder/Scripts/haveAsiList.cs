using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haveAsiList : MonoBehaviour
{
    public static bool[] asiList = new bool[8];
    public static int [] curHaveList = new int[8];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < curHaveList.Length; i++) {
            curHaveList[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //debugText.text = "asiList\n";
        //Debug.Log(curHaveList[0]);
        //for (int i = 0; i < asiList.Length; i++) {
            //Debug.Log(i+":"+asiList[i]);
        //    debugText.text += i+")"+ asiList[i]+"\n";
        //}
    }
}
