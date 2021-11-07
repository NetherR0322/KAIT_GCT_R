using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainsSound : MonoBehaviour
{
	private AudioSource sound01;
	GameObject barrierrod;
	BarrierRodScript barrierRod;

	void Start()
	{
		barrierrod = GameObject.Find("BarrierRod");
	}

	void Update()
	{
		barrierRod = barrierrod.GetComponent<BarrierRodScript>();
		if (barrierRod.state == 0 || barrierRod.state == 3 || barrierRod.state == 1)
		{
			var colliderTest = GetComponent<AudioSource>();
			colliderTest.enabled = true;
		}
		if (barrierRod.state == 2)
		{
			var colliderTest = GetComponent<AudioSource>();
			colliderTest.enabled = false;
		}
	}

}