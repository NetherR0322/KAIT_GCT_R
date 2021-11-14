using UnityEngine;
using System.Collections;

public class BarrierRodScript1 : MonoBehaviour
{
    //カウントアップ
    
    //タイムリミット
    private float rotateSize = 0.0f;
    private float openLimit = 359.1f;
    private float closeLimit = 304.0f;
    public int state = 0;
    private void Start()
    {
    }
    void Update()
    {

        if (state == 0 )
        {
            rotateSize = gameObject.transform.localEulerAngles.z;
    
        }
        if (state == 1)
        {
            transform.Rotate(new Vector3(0, 0, 0.4f));
            rotateSize += 0.4f;
            Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.z);
        }
        
        if (state == 2)
        {
    
        }

        if (state == 2)
        {
    
        }
        if (state == 3)
        {
            transform.Rotate(new Vector3(0, 0, -0.4f));
            Debug.Log("現在の角度"+gameObject.transform.localEulerAngles.z);
            rotateSize -= 0.4f;
        }
    }
}