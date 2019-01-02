using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {
	public float moveSpeed = 5.0f;
	public float drag = 0.5f;
	public float terminalRotationSpeed = 25.0f;
	public Vector3 MoveVector{set; get;}
	public VirtualJoyStick joystick;

	private Rigidbody thisRigidbody;

	// Use this for initialization
	void Start () {
		thisRigidbody = gameObject.AddComponent<Rigidbody>();
		thisRigidbody.maxAngularVelocity = terminalRotationSpeed;
		thisRigidbody.drag = drag;
	}
	
	// Update is called once per frame
	private void Update () {
		MoveVector = PoolInput();

		Move();	
	}

	private void Move (){
		//thisRigidbody.AddForce(MoveVector * moveSpeed);
		thisRigidbody.velocity = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye) * MoveVector * moveSpeed;
		Debug.Log(thisRigidbody.velocity);
	}

	private Vector3 PoolInput(){
		Vector3 dir = Vector3.zero;

		dir.x = -joystick.Horizontal();
		dir.z = -joystick.Vertical();

		if (dir.magnitude > 1){
			dir.Normalize();
		}

		return dir;
	}
}
