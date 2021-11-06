using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumikiriScript : MonoBehaviour
{
    [SerializeField]
    bool Fumikiri_flg = false;

    private float HumikiriAngle = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Fumikiri_flg == true)
        {
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
