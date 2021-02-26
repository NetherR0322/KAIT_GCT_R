using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curData : MonoBehaviour
{
    public int haveId;
    GamePlayer data;
    private GameObject tako;
    Rigidbody2D rb;
    public Vector3 beforePos;
    Vector3 nowPos;
    public Vector3 thisPos;
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
        thisPos = this.transform.position;
        beforePos = nowPos;
        nowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (haveId == -1 && data.isClicked&&nowPos.y<beforePos.y) {
            rb.AddForce(new Vector3(0.0f,0.01f), ForceMode2D.Impulse);
        }
        if (haveId == -1 && data.isClicked && nowPos.y > beforePos.y)
        {
            rb.AddForce(new Vector3(0.0f, -0.01f), ForceMode2D.Impulse);
        }
        if (haveId == -1 && data.isClicked && nowPos.x < beforePos.x)
        {
            rb.AddForce(new Vector3(0.01f, 0.0f), ForceMode2D.Impulse);
        }
        if (haveId == -1 && data.isClicked && nowPos.x > beforePos.x)
        {
            rb.AddForce(new Vector3(-0.01f, 0.0f), ForceMode2D.Impulse);
        }
    }
}
