using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class dragMover : MonoBehaviourPunCallbacks
{
    public Vector3 beforePos;
    Vector3 nowPos;
    public Vector3 thisPos;

    private GameObject tako;

    Rigidbody2D rb;

    public float power = 0.01f;

    private bool canMove;
    public float distance = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        tako = this.gameObject;// GameObject.FindGameObjectWithTag("tako");
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
        if (canMove&& Input.GetMouseButton(0))
        {
            thisPos = this.transform.position;
            beforePos = nowPos;
            nowPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (nowPos.y < beforePos.y)
            {
                rb.AddForce(new Vector3(0.0f, power), ForceMode2D.Impulse);
            }
            if (nowPos.y > beforePos.y)
            {
                rb.AddForce(new Vector3(0.0f, -power), ForceMode2D.Impulse);
            }
            if (nowPos.x < beforePos.x)
            {
                rb.AddForce(new Vector3(power, 0.0f), ForceMode2D.Impulse);
            }
            if (nowPos.x > beforePos.x)
            {
                rb.AddForce(new Vector3(-power, 0.0f), ForceMode2D.Impulse);
            }
        }
        GetComponent<PhotonView>().RPC(nameof(TransformSync), RpcTarget.All, this.transform.position);//@
    }

    private void TransformSync(Vector2 pos)
    {
        this.transform.position = pos;
    }

    float Distance(Vector2 fPos, Vector2 sPos)
    {
        float ans = Mathf.Pow(fPos.x - sPos.x, 2) + Mathf.Pow(fPos.y - sPos.y, 2);
        return ans;
    }
}
