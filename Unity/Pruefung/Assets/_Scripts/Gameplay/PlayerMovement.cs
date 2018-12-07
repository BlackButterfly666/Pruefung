using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Transform cam;
	public float speed = 4f;
	public float jumpSpeed = 7f;
	public float gravity = 20f;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 cameraRot;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		Move();
		//LockMouse();
		//ReleaseMouse();
	}

	public void Move()
	{
		CharacterController controller = GetComponent<CharacterController>();

		// is the controller on the ground?
		if (controller.isGrounded)
		{
			//Feed moveDirection with input.
			
			//moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			
			//Transform local values to world space
			moveDirection = transform.TransformDirection(moveDirection);

			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (Input.GetButton("Jump")) { moveDirection.y = jumpSpeed; }
		}

		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);
	}

	//public void LockMouse()
	//{
	//	if (Input.GetKeyDown(KeyCode.L))
	//	{ Cursor.lockState = CursorLockMode.Locked; }
	//}

	//public void ReleaseMouse()
	//{
	//	if (Input.GetKeyDown(KeyCode.U))
	//	{ Cursor.lockState = CursorLockMode.None; }
	//}
}
