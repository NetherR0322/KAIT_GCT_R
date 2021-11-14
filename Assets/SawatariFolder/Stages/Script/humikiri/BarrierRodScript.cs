using UnityEngine;
using System.Collections;

public class BarrierRodScript : MonoBehaviour
{
    //カウントアップ
    private float countup = 0.0f;
    BarrierTriggerScript barrierTrigger;
    GameObject BarrierTrigger;
    GameObject barrierrod1;
    BarrierRodScript1 barrierRod1;
    //タイムリミット
    public float timeLimit = 30.0f;
    private float rotateSize = 0.0f;
    private float openLimit = 284.0f;
    private float closeLimit = 359.1f;
    public int state = 0;
    private void Start()
    {
        BarrierTrigger = GameObject.Find("BarrierTrigger");
        barrierrod1 = GameObject.Find("BarrierRod1");
    }
    void Update()
    {
        barrierTrigger = BarrierTrigger.GetComponent<BarrierTriggerScript>();
        barrierRod1 = barrierrod1.GetComponent<BarrierRodScript1>();
        if (state == 0 && barrierTrigger.Hit == true)
        {
            rotateSize = gameObject.transform.localEulerAngles.y;
            state = 1;
            barrierTrigger.Hit = false;
            barrierRod1.state = 1;
            // Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.y);
        }
        if (state == 1)
        {
            transform.Rotate(new Vector3(0, -0.4f, 0f));
            rotateSize -= 0.4f;
            //Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.y);
        }
        if (state == 1 && rotateSize < openLimit)
        {
            state = 2;
            barrierRod1.state = 2;
        }
        if (state == 2)
        {
            countup += Time.deltaTime;
        }

        if (state == 2 && countup >= timeLimit)
        {
            state = 3;
            countup = 0.0f;
            barrierRod1.state = 3;
        }
        if (state == 3)
        {
            transform.Rotate(new Vector3(0, 0.4f, 0));
            //Debug.Log("現在の角度"+gameObject.transform.localEulerAngles.y);
            rotateSize += 0.4f;
        }
        if (state == 3 && rotateSize > closeLimit)
        {
            state = 0;
            barrierRod1.state = 0;
        }
    }
}