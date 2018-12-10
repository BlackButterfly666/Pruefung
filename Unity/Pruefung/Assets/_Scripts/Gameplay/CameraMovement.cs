using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] public Transform player;
	public Vector2 camMove;

	private void Update()
	{
		camMove.x = player.transform.position.x;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("ground")) { camMove.y = player.transform.position.y; }
	}
}
