using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour
{
	private float nextTime;
	float alpha_Sin;
	GameObject barrierrod;
	BarrierRodScript barrierRod;
	// Use this for initialization
	private float countup = 0.0f;
	public bool first = true;
	private bool power = true;
	void Start()
	{
		nextTime = Time.time;
		barrierrod = GameObject.Find("BarrierRod");
	}

	// Update is called once per frame
	void Update()
	{
		var colliderTest = GetComponent<SpriteRenderer>();
		barrierRod = barrierrod.GetComponent<BarrierRodScript>();
		if (first == true && power == false)
		{
			colliderTest.enabled = true;

		}
		if (barrierRod.state == 0 || barrierRod.state == 3)
		{
			power = true;

			countup += Time.deltaTime;
			if (countup > 0.85f)
			{
				colliderTest.enabled = !colliderTest.enabled;
				countup = 0f;
			}
		}
		if (barrierRod.state == 1 || barrierRod.state == 2)
		{

			colliderTest.enabled = false;
			power = false;

		}

	}
}