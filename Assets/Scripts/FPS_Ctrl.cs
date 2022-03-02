using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Ctrl : MonoBehaviour {
	Rigidbody rb;
	public float spdCoff, jmpCoff;
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	private void Update() {
		if(Input.GetKeyDown(KeyCode.Space)){
			//Physics.SphereCast(transform.position , 0.2f, Vector3.down, out HumanPartDof, );
			rb.velocity += transform.up * jmpCoff;
		}
		rb.AddForce((transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")) * spdCoff * Time.deltaTime, ForceMode.Impulse);
	}
}
