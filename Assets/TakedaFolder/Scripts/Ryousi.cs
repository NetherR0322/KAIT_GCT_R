using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ryousi : MonoBehaviour
{
    public GameObject Ami;
    public float shotSpeed;

    private int shotIntarval;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shotIntarval += 1;

        if (shotIntarval % 360 == 0)
        {
            GameObject enemyShell = Instantiate(Ami, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向（青軸方向）・・・＞この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

  

            Destroy(enemyShell, 3.0f);
        }

    }
}

