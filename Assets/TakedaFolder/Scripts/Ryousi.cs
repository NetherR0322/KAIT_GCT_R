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

        if (shotIntarval % 1260 == 0)
        {
            GameObject enemyShell = Instantiate(Ami, transform.position, Quaternion.identity);

            Rigidbody2D enemyShellRb = enemyShell.GetComponent<Rigidbody2D>();

            // forwardはZ軸方向（青軸方向）・・・＞この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);
         

            Destroy(enemyShell, 30.0f);
        }

    }
}

