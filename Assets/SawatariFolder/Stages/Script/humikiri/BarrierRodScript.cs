using UnityEngine;
using System.Collections;
using Photon.Pun;

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
    public bool trainCanRun = true;
    public bool trainTrigger = false;
    public float rotateAngle;
    private bool stateChanged;
    private void Start()
    {
        BarrierTrigger = GameObject.Find("BarrierTrigger");
        barrierrod1 = GameObject.Find("BarrierRod1");
    }
    void Update()
    {
        Debug.Log("STATE:"+state);
        barrierTrigger = BarrierTrigger.GetComponent<BarrierTriggerScript>();
        barrierRod1 = barrierrod1.GetComponent<BarrierRodScript1>();
        if (state == 0&& barrierTrigger.Hit == true)
        {
            trainCanRun = true;
            trainTrigger = true;
            Debug.Log("12345678");
            rotateSize = gameObject.transform.localEulerAngles.y;
            state = 1;
            stateChanged = true;
            barrierTrigger.Hit = false;
            barrierRod1.state = 1;
            // Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.y);
        }
        if (state == 1)
        {
            transform.Rotate(new Vector3(0, rotateAngle*Time.deltaTime, 0f));
            rotateSize += rotateAngle * Time.deltaTime;
            //Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.y);
        }
        if (state == 1 && rotateSize < openLimit)
        {
            trainCanRun = false;
            trainTrigger = true;
            state = 2;
            stateChanged = true;
            barrierRod1.state = 2;
        }
        if (state == 2)
        {
            countup += Time.deltaTime;
        }

        if (state == 2 && countup >= timeLimit)
        {
            state = 3;
            stateChanged = true;
            countup = 0.0f;
            barrierRod1.state = 3;
        }
        if (state == 3)
        {
            transform.Rotate(new Vector3(0, -(rotateAngle * Time.deltaTime), 0));
            //Debug.Log("現在の角度"+gameObject.transform.localEulerAngles.y);
            rotateSize -= rotateAngle * Time.deltaTime;
        }
        if (state == 3 && rotateSize > closeLimit)
        {
            state = 0;
            stateChanged = true;
            barrierRod1.state = 0;
        }
        if(stateChanged&&PhotonNetwork.IsMasterClient) GetComponent<PhotonView>().RPC(nameof(StateChanger), RpcTarget.All,state);
    }
    [PunRPC]
    private void StateChanger(int num)
    {
        Debug.Log("STATE CHANGED!!");
        state = num;
        barrierRod1.state = num;
    }
}