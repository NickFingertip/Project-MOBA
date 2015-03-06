using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerScript : MonoBehaviour {

	public float speed = 6.0F;
	private float actualSpeed;
	private bool dashing;
	public float dashTime = 0.35f;
	private float _dashTime;
	public float jumpSpeed = 8.0F;
	public float dashSpeed = 20.0f;
	public float gravity = 20.0F;
	public int jumpNumber = 1;
	private int jumpCount = 0;
	private Vector3 moveDirection = Vector3.zero;
	private bool jumping = false;

	private CharacterController controller;
	
	void Start(){
		controller = GetComponent<CharacterController>();
		actualSpeed = speed;

		//Cursor.visible = false;

	}
	
	void Update() {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		if (Input.GetKeyDown (KeyCode.Escape))
			Application.LoadLevel (0);


		if (Input.GetKeyDown(KeyCode.V) && !dashing) {
			_dashTime = dashTime;
			dashing = true;
		}

		if(dashing){
			actualSpeed = dashSpeed;
			_dashTime -= Time.deltaTime;

			if(_dashTime <= 0) dashing = false;
		}
		else{
			actualSpeed = speed;
		}

		if (controller.isGrounded) {
			jumpCount = 0;

			moveDirection = new Vector3(inputX, 0, inputY);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= actualSpeed;

			if(jumping){
				jumping = false;
			}

		}
		else{
			jumping = true;

			moveDirection.x = inputX * actualSpeed;
			moveDirection.z = inputY * actualSpeed;
			moveDirection = transform.TransformDirection(moveDirection);
		}
		
		if (Input.GetButtonDown("Jump")) {
			if(jumpCount < jumpNumber){
				jumpCount++;
				moveDirection.y = jumpSpeed;
			}
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
