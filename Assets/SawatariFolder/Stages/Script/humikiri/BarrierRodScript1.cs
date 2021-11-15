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
    public float rotateAngle;
    public GameObject rod;
    private void Start()
    {
    }
    void Update()
    {
        transform.rotation = rod.transform.rotation;
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z+180);
        /*
        Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.y);
        if (state == 0)
        {
            rotateSize = gameObject.transform.localEulerAngles.y;

        }
        if (state == 1)
        {
            transform.Rotate(new Vector3(0, rotateAngle*Time.deltaTime, 0));
            rotateSize += rotateAngle * Time.deltaTime;
            // Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.y);
        }

        if (state == 2)
        {

        }

        if (state == 2)
        {

        }
        if (state == 3)
        {
            transform.Rotate(new Vector3(0, -(rotateAngle * Time.deltaTime), 0));
            // Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.y);
            rotateSize -= rotateAngle * Time.deltaTime;
        }
        */
    }
}