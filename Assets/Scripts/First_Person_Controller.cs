using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class First_Person_Controller : MonoBehaviour {

	public float walkSpeed;
	public float runSpeed;
	public float gravity;
	public float mouseSpeed;
	public float pitchClamp;
	private CharacterController characterController;

	private float time;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();
		AplicationModel.clearVariables ();
		AplicationModel.begin_time = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		movement = characterController.camera.transform.rotation * movement;
		if (characterController.isGrounded) {
			movement *= walkSpeed;
		}
		movement.y -= gravity;
		Vector3 rotation = new Vector3 (0, Input.GetAxis ("Mouse X"), 0);
		rotation *= mouseSpeed;
		rotation *= Time.deltaTime;
		characterController.Move (movement * Time.deltaTime);
		characterController.camera.transform.Rotate (rotation);
	}
}
