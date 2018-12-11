using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] public Transform player;
	[SerializeField] Camera cam;
	Vector3 camMove;

	private void OnAwake()
	{
		Set();
		cam.transform.position = camMove;
	}

	Vector3 Set()
	{
		camMove.Set(0.4f, 2.5f, -8f);
		return camMove;
	}

	private void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("ground"))
		{
			camMove.y = player.transform.position.y;
		}
	}

	void MovePlayer()
	{
		if (player.transform.position != Vector3.zero)
		{
			Debug.Log("nicht Null");
		}
		//camMove.x = player.transform.position.x;
		//cam.transform.position = camMove;
		////player.transform.position.x;
	}
}
