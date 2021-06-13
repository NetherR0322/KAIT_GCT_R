using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kyori : MonoBehaviour
{
    public Text distance;
    public Transform tako;
    public Transform goal;
    float _distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(tako.position, goal.position);
        distance.text = "海まであと"+_distance.ToString("f0")+"m";
    }
}
