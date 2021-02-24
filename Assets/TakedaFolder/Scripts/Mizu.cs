using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mizu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "tako")
        {
            GameObject tako = GameObject.Find("tako");
            //ぶつかった時に色を変更する

        }
    }
}
