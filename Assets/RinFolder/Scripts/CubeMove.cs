using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CubeMove : MonoBehaviour
{
    private Vector3 mouse;
    private Vector3 target;

    void Update()
    {
        mouse = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
        this.transform.position = target;
    }
}