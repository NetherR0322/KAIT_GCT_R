using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BarrierLampSound : MonoBehaviour
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
		if (barrierRod.state == 0 || barrierRod.state == 3)
		{
			var colliderTest = GetComponent<AudioSource>();
			colliderTest.enabled = true;
		}
		if (barrierRod.state == 1 || barrierRod.state == 2)
		{
			var colliderTest = GetComponent<AudioSource>();
			colliderTest.enabled = false;
		}
	}

}