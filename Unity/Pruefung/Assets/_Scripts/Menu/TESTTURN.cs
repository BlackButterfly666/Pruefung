using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTTURN : MonoBehaviour
{
	[SerializeField] RectTransform MainMenu;
	[SerializeField] RectTransform Settings;
	[SerializeField] RectTransform Credits;
	[SerializeField] GameObject Cube;
	Quaternion center;
	Quaternion right;
	Quaternion left;

	void Start()
	{
		center.Set(0, 0, 0, 1);
		right.Set(0, -90, 0, 1);
		left.Set(0, 90, 0, 1);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.L)) { TurnLeft(); }
		else if (Input.GetKeyDown(KeyCode.R)) { TurnRight(); }
		else if (Input.GetKeyDown(KeyCode.Space)) { TurnCenter(); }
		else { Debug.Log("Please push R for right turn, L for left turn or space for center turn"); }
	}

	void TurnRight()
	{
		Cube.transform.SetPositionAndRotation(transform.position, center);

	}

	void TurnLeft()
	{
		Cube.transform.SetPositionAndRotation(transform.position, left);

	}

	void TurnCenter()
	{
		Cube.transform.SetPositionAndRotation(transform.position, right);
	}
}
