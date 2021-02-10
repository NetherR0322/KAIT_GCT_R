using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TakoMover : MonoBehaviour
{
    public float speed = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tako_x = Input.GetAxisRaw("Horizontal");
        float tako_y = Input.GetAxisRaw("Vertical");
        this.transform.position += new Vector3(tako_x*speed, tako_y*speed);
    }
}
