using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curData : MonoBehaviour
{
    public int haveId;
    GamePlayer data;
    private GameObject tako;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        haveId = -1;
        tako= GameObject.FindGameObjectWithTag("tako");
        data = GetComponent<GamePlayer>();
        rb = tako.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (haveId == -1 && data.isClicked) {
            rb.AddForce(new Vector3(0.0f,0.01f), ForceMode2D.Impulse);
        }
    }
}
