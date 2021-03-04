using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float Times;
    float Xsize = 2.469088f;
    float Ysize = 2.469088f;
    private Vector3 targetps;
    public float speed = -0.1f;
    // Start is called before the first frame update
    void Start()
    {
        targetps = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Times = Time.time + 10;
        targetps.x = targetps.x + speed;
        transform.position = new Vector3(targetps.x, targetps.y, targetps.z);

    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Return")
        {
            Vector3 crow = new Vector3(Xsize, Ysize, 1);
            crow.x = crow.x * -1;
            Xsize = Xsize * -1;
            speed = speed * -1;
            gameObject.transform.localScale = crow;

        }
    }
}
