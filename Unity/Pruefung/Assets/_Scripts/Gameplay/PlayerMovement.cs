using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 4f;
	public float jumpSpeed = 7f;
	public float gravity = 20f;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
    private Animator animator;
	//[SerializeField]

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
	}

	void Update()
	{
		Move();
		//LockMouse();
		//ReleaseMouse();s
		
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            EventManager.Instance.ChangeMenu.Invoke(ActiveMenu.PauseMenu);
        }
	}

	public void Move()
	{

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


        animator.SetFloat("WalkingSpeed", System.Math.Abs(moveDirection.x));

        if (moveDirection.x != 0)
            animator.SetTrigger("WalkingTrigger");

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
