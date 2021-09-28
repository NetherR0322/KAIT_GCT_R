using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takoBodyPos : MonoBehaviour
{
    bool canMove;
    public float distance = 12.0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] IKs = GameObject.FindGameObjectsWithTag("IK");
        canMove = true;
        for (int i = 0; i < IKs.Length; i++)
        {
            float dist = Distance(this.transform.position, IKs[i].gameObject.transform.position);
            if (dist > distance) canMove = false;
            Debug.Log("["+i+".dis]:"+dist);
        }
        if (canMove)
        {
                Vector2 hopePos=Vector3.Lerp(
                Vector3.Lerp(Vector3.Lerp(IKs[0].transform.position, IKs[1].transform.position, 0.5f),
                Vector3.Lerp(IKs[2].transform.position, IKs[3].transform.position, 0.5f), 0.5f),
                Vector3.Lerp(Vector3.Lerp(IKs[4].transform.position, IKs[5].transform.position, 0.5f),
                Vector3.Lerp(IKs[6].transform.position, IKs[7].transform.position, 0.5f), 0.5f), 0.5f);

            Vector2 thisPos = this.transform.position;
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3((hopePos.x - thisPos.x), (hopePos.y - thisPos.y)), ForceMode2D.Impulse);
        }
    }
    float Distance(Vector2 fPos, Vector2 sPos)
    {
        float ans = Mathf.Pow(fPos.x - sPos.x, 2) + Mathf.Pow(fPos.y - sPos.y, 2);
        return ans;
    }

}
