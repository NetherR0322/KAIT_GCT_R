using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Drag()
    {
        Vector3 TargetPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
        TargetPos.z = 0;
        transform.parent.position = TargetPos;
        Debug.Log("Drag");
    }
}
