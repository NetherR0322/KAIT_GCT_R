using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            var dx = 0.1f * Input.GetAxis("Horizontal");
            var dy = 0.1f * Input.GetAxis("Vertical");
            transform.Translate(dx, dy, 0f);
        
    }
}
