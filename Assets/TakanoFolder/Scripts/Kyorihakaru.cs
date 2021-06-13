using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kyorihakaru : MonoBehaviour
{
    public Text distance;
    public Transform tako;
    public Transform goal;
    float a;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        a = Vector3.Distance(tako.position, goal.position);
        distance.text = "海まであと" + a.ToString("f0") + "m";
    }
}
