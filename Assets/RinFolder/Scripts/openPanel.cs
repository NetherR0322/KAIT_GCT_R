using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void open(GameObject go){
	    go.SetActive(true);
	    }
	public void close(GameObject go){
	    go.SetActive(false);
	    }
}
