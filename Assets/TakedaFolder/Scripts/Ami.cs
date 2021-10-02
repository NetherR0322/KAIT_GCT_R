using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ami : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "tako")
        {
            col.gameObject.GetComponent<takoBodyPos>().hitTrap = 6.0f;
            col.gameObject.GetComponent<takoBodyPos>().hitTrapF = true;
            Destroy(this.gameObject);
        }
    }
}
