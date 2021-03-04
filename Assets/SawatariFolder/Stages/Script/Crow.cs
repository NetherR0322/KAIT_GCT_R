using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    float Times;
     float Xsize= 1.494188f;
    float Ysize= 1.494188f;
    private Vector3 targetps;
    public float speed ;
    // Start is called before the first frame update
    void Start()
    {
        targetps = transform.position;
        speed = -0.01f;
    }

    // Update is called once per frame
    void Update()
    {
       Times = Time.time+10;
        targetps.x=targetps.x + speed;
        transform.position = new Vector3(targetps.x, targetps.y, targetps.z);
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
       
        
    }
    void OnTriggerEnter2D(Collider2D col) {
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
