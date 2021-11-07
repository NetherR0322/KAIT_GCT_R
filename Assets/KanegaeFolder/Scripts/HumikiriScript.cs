using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumikiriScript : MonoBehaviour
{
   [SerializeField]
    public static bool Fumikiri_flg = false;

    public static float HumikiriAngle = 0;

    float count;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count >= 15.0f)
        {
            Fumikiri_flg = true;
        }
       
        if (Fumikiri_flg == true)
        {
            count = 0f;
            if (HumikiriAngle <= 90)
            {
                HumikiriAngle += (Time.deltaTime*5);
            }
            
        }
        else
        {
            if (HumikiriAngle >= 0)
            {

                HumikiriAngle -= (Time.deltaTime*10);
              
            }
        }
        transform.eulerAngles = new Vector3(0, 0,HumikiriAngle);
    }
}
