using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class isShow : MonoBehaviour
{

	Camera targetCamera; // 映っているか判定するカメラへの参照

	public Transform[] targetObj; // 映っているか判定する対象への参照。inspectorで指定する

	Rect rect = new Rect(0.025f, 0.025f, 0.975f, 0.975f); // 画面内か判定するためのRect

	public float backSpeed;
	void Start()
	{
		targetCamera = GetComponent<Camera>();
	}

	void Update()
	{
		for (int i = 0; i < targetObj.Length; i++)
		{
			var viewportPos = targetCamera.WorldToViewportPoint(targetObj[i].position);
			if (!rect.Contains(viewportPos))
			{
				Transform target = targetObj[i];
				Vector2 targetPos = new Vector2(0, 0);
				if (target.position.x > this.transform.position.x) targetPos.x = -1;
				if (target.position.x < this.transform.position.x) targetPos.x = 1;
				if (target.position.y > this.transform.position.y) targetPos.y = -1;
				if (target.position.y < this.transform.position.y) targetPos.y = 1;
				target.position = new Vector2(target.position.x + backSpeed * targetPos.x, target.position.y + backSpeed * targetPos.y);
			}
		}
	}
}