using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierTriggerScript : MonoBehaviour
{

    public bool Hit = false;
    // Start is called before the first frame update
    void Start()
    {
        Hit = false;
    }

    // Update is called once per frame
    void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "train")
        {
            Hit = true;
        }
    }
}