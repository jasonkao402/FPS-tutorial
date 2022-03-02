using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Ctrl : MonoBehaviour {
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
		rb.AddForce((transform.forward * Input.GetAxisRaw("Vertical")  + 
					 transform.right * Input.GetAxisRaw("Horizontal")) * 
					 spdCoff * Time.deltaTime, ForceMode.VelocityChange);
	}
	private void FixedUpdate() {
		groundCheck = Physics.SphereCast(transform.position, 0.2f,
					  Vector3.down, out hitInfo, maxCheckHeight, 1<<6);
	}
}
