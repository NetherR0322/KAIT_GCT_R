using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowtest : MonoBehaviour
{
    float Times;
    public float Xsize = 1.494188f;
    public float Ysize = 1.494188f;
    private Vector3 targetps;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Return")
        {
            Vector3 crow = new Vector3(Xsize, Ysize, 1);
            crow.x = crow.x * -1;
            Xsize = Xsize * -1;
            gameObject.transform.localScale = crow;
            Debug.Log("OK!!");
        }
    }
}
