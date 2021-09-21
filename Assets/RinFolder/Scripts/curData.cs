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

    public float power = 0.01f;

    private bool canMove;
    public float distance=1.0f;
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
        GameObject[] IKs = GameObject.FindGameObjectsWithTag("IK");
        canMove = true;
        for (int i = 0; i < IKs.Length; i++)
        {
            float dist = Distance(this.transform.position, IKs[i].gameObject.transform.position);
            if (dist <= distance) canMove = false;
        }
        if (canMove)
        {
            thisPos = this.transform.position;
            beforePos = nowPos;
            nowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (haveId == -1 && data.isClicked && nowPos.y < beforePos.y)
            {
                rb.AddForce(new Vector3(0.0f, power), ForceMode2D.Impulse);
            }
            if (haveId == -1 && data.isClicked && nowPos.y > beforePos.y)
            {
                rb.AddForce(new Vector3(0.0f, -power), ForceMode2D.Impulse);
            }
            if (haveId == -1 && data.isClicked && nowPos.x < beforePos.x)
            {
                rb.AddForce(new Vector3(power, 0.0f), ForceMode2D.Impulse);
            }
            if (haveId == -1 && data.isClicked && nowPos.x > beforePos.x)
            {
                rb.AddForce(new Vector3(-power, 0.0f), ForceMode2D.Impulse);
            }
        }
    }

    float Distance(Vector2 fPos, Vector2 sPos)
    {
        float ans = Mathf.Pow(fPos.x - sPos.x, 2) + Mathf.Pow(fPos.y - sPos.y, 2);
        return ans;
    }
}
