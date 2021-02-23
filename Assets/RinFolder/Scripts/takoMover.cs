using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takoMover : MonoBehaviour
{
    float dist;
    curData data;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //全てのカーソルを取得
        GameObject[] cursors = GameObject.FindGameObjectsWithTag("Cursor");
        for (int i = 0; i < cursors.Length; i++)
        {
            data = cursors[i].GetComponent<curData>();
        }
    }
}
