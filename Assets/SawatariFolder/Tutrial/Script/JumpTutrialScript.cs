using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTutrialScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("すり抜けている");
        if (other.gameObject.tag == "tako")
        {
            Debug.Log("タコがコンロのトリガーをすり抜けている");
            GMScript.Movetutrial = false;
            GMScript.Jumptutrial = true;
        }
    }
}
