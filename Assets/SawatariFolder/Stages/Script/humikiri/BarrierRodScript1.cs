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
        Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.y);
        if (state == 0)
        {
            rotateSize = gameObject.transform.localEulerAngles.y;

        }
        if (state == 1)
        {
            transform.Rotate(new Vector3(0, -0.4f, 0));
            rotateSize += 0.4f;
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
            transform.Rotate(new Vector3(0, 0.4f, 0));
            // Debug.Log("現在の角度" + gameObject.transform.localEulerAngles.y);
            rotateSize -= 0.4f;
        }
    }
}