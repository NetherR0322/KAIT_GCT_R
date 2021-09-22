using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KaiScript : MonoBehaviour
{
    public static int rate;

    public  Text Ratetext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Ratetext.text = rate + "/3";
    }
}
