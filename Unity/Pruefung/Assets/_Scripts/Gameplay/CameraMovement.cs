using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] public Transform player;
	//[SerializeField] PlayerMovement playerMove;
	public Vector2 camMove;

	private void Update()
	{
		camMove.x = player.transform.position.x;

		//if (Player.colCheck) { }
		camMove.y = player.transform.position.y;
	}


}
