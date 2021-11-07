using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenshaPop : MonoBehaviour
{

    private GameObject DenshaPrefab;

    private bool trainflg = false;

    private GameObject Densha;

    // Start is called before the first frame update
    void Start()
    {
        DenshaPrefab = Resources.Load("densha") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(HumikiriScript.HumikiriAngle >= 90)
        {
            if(trainflg == false)
            {
                PopTrain();
            }            
        } 

        if(Densha.transform.position.x <= -90)
        {
            GameObject.Destroy(Densha);
            HumikiriScript.Fumikiri_flg = false;
        }
    }

    private void PopTrain()
    {
       Densha  = Instantiate(DenshaPrefab, new Vector3(80,48,0), Quaternion.identity, transform);
        trainflg = true;
    }

}
