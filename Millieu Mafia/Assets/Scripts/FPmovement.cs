using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// First-person shooter controller that handles player movement, jumping, and camera rotation.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class FpMovement : MonoBehaviour
{
	public Camera playerCamera; // The player's camera.
	public float walkSpeed = 6f; // Walk speed of the player.
	public float runSpeed = 12f; // Run speed of the player.
	public float jumpPower = 7f; // Jump power of the player.
	public float gravity = 10f; // Gravity applied to the player.

	public float lookSpeed = 2f; // Speed of camera rotation.
	public float lookXLimit = 45f; // Limit for vertical camera rotation.

	Vector3 moveDirection = Vector3.zero; // Movement direction of the player.
	float rotationX = 0; // Rotation around the X-axis.

	public bool canMove = true; // Flag indicating if the player can move.

	CharacterController characterController; // Reference to the CharacterController component.

	void Start()
	{
		characterController = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
		#region Handles Movement

		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 right = transform.TransformDirection(Vector3.right);

		// Press Left Shift to run
		bool isRunning = Input.GetKey(KeyCode.LeftShift);
		float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
		float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
		float movementDirectionY = moveDirection.y;
		moveDirection = (forward * curSpeedX) + (right * curSpeedY);

		#endregion

		#region Handles Jumping

		if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
		{
			moveDirection.y = jumpPower;
		}
		else
		{
			moveDirection.y = movementDirectionY;
		}

		if (!characterController.isGrounded)
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}

		#endregion

		#region Handles Rotation
		if (PauseMenuManager.isPaused == false)
		{
			characterController.Move(moveDirection * Time.deltaTime);

			if (canMove)
			{
				rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
				rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
				playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
				transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
			}
		}
        #endregion
        if (PauseMenu.isPaused) 
		{
			lookSpeed = 0f;
		}
        else
        {
			lookSpeed = 2f;
        }
	}
}
