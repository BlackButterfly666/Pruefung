using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 4f;
	public float jumpSpeed = 7f;
	public float gravity = 20f;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
    private Animator animator;
    private SpriteRenderer renderer;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        renderer = GetComponentInChildren<SpriteRenderer>();
    }

	void Update()
	{
		Move();
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
        
		//sprite turn to movement direction
        renderer.flipX = moveDirection.x == 0 ? renderer.flipX : moveDirection.x < 0;

        animator.SetFloat("WalkingSpeed", System.Math.Abs(moveDirection.x));

        if (moveDirection.x != 0)
            animator.SetTrigger("WalkingTrigger");

		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);
	}
}
