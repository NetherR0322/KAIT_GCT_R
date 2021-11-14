using UnityEngine;
using System.Collections;

public class BarrierRodScript : MonoBehaviour
{
    //カウントアップ
    private float countup = 0.0f;
    BarrierTriggerScript barrierTrigger;
    GameObject BarrierTrigger;
    //タイムリミット
    public float timeLimit = 30.0f;
    private float rotateSize = 0.0f;


    public int state = 0;
    private void Start()
    {
        BarrierTrigger = GameObject.Find("BarrierTrigger");
    }
    void Update()
    {
        barrierTrigger = BarrierTrigger.GetComponent<BarrierTriggerScript>();

        if (state == 0 && barrierTrigger.Hit == true)
        {
            rotateSize = gameObject.transform.localEulerAngles.z;
            state = 1;
            barrierTrigger.Hit = false;
        }
        if (state == 1)
        {
            transform.Rotate(new Vector3(0, 0, -0.4f));
            rotateSize -= 0.4f;
            //Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.z);
        }
        if (state == 1 && rotateSize < 304)
        {
            state = 2;
        }
        if (state == 2)
        {
            countup += Time.deltaTime;
        }

        if (state == 2 && countup >= timeLimit)
        {
            state = 3;
            countup = 0.0f;
        }
        if (state == 3)
        {
            transform.Rotate(new Vector3(0, 0, 0.4f));
            //Debug.Log("現在の角度"+gameObject.transform.localEulerAngles.z);
            rotateSize += 0.4f;
        }
        if (state == 3 && rotateSize > 359.1)
        
        {
            state = 0;
        }
    }
}