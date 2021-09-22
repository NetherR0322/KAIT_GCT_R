using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kyorihakaru : MonoBehaviour
{
    public Text distance;
    public Transform tako;
    public Transform goal;
    public static float dis;
    // Start is called before the first frame update
    void Start()
    {
        dis = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(tako.position, goal.position);
        distance.text = "海まであと" + dis.ToString("f0") + "m";

        
    }
}
