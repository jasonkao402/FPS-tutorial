using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCtrl : MonoBehaviour {
	public Transform cam;
	Vector3 vHeading;
	Quaternion cHeading;
	Rigidbody rb;
	public float spdCoff, jmpCoff, maxCheckHeight;
	RaycastHit hitInfo;
	public bool groundCheck;
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	private void Update() {
		if(groundCheck && Input.GetKeyDown(KeyCode.Space)){
			rb.velocity += transform.up * jmpCoff;
		}
	}
	private void FixedUpdate() {
		cHeading = Quaternion.Euler(0, cam.eulerAngles.y, 0);
		vHeading = cHeading * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

		transform.forward = Vector3.Slerp(transform.forward, vHeading, 0.1f);

		rb.AddForce( vHeading * spdCoff, ForceMode.VelocityChange);

		groundCheck = Physics.SphereCast(transform.position, 0.2f,
					  Vector3.down, out hitInfo, maxCheckHeight, 1<<6);
	}
}
