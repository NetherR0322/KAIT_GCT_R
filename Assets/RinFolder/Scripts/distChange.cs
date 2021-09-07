using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distChange : MonoBehaviour
{
    public GameObject target;
    private float dist;
    public Sprite before;
    public Sprite after;
    public float distance;

    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist= Mathf.Sqrt(Mathf.Pow(this.transform.position.x - target.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - target.transform.position.y, 2));
        if (dist >= distance)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = after;
            arrow.SetActive(true);
        }
        if (dist < distance)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = before;
            arrow.SetActive(false);
        }
    }
}
