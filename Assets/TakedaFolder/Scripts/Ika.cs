using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ika : MonoBehaviour
{
    private Vector3 targetps;
    // Start is called before the first frame update
    void Start()
    {
        targetps = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 2.5f + targetps.x, targetps.y, targetps.z);
        }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "tako")
        {
            GameObject tako = GameObject.Find("tako");
        
        }
    }
}
