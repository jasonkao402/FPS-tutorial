using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsMove : MonoBehaviour
{
    public float runSpd;
    public float tiltAng = 12;
    float drag;
    public Transform head, tilt;
    Vector3 dir;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        drag = rb.drag;
    }

    private void FixedUpdate() {
        dir = Input.GetAxisRaw("Horizontal")*transform.right + Input.GetAxisRaw("Vertical")*transform.forward;
        rb.AddForce(dir.normalized * Mathf.Lerp(runSpd, runSpd*0.1f, Input.GetAxis("Sneak")), ForceMode.VelocityChange);
        tilt.localRotation = Quaternion.Slerp(tilt.localRotation, Quaternion.AngleAxis(Input.GetAxisRaw("Tilting")*tiltAng, Vector3.forward), 0.2f);
        // rb.drag = Mathf.Lerp(drag, drag*0.25f, Input.GetAxisRaw("Sneak"));

        
        // head.localPosition = Vector3.Lerp(head.localPosition, new Vector3(0, Mathf.Lerp(2f, 0.666f, Input.GetAxisRaw("Sneak")), 0), 0.15f);
    }
}
