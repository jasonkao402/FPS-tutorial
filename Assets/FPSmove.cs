using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsMove : MonoBehaviour
{
    public float runSpd, tiltAng;
    public Transform[] body;
    Vector3 dir;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        dir = Input.GetAxisRaw("Horizontal")*transform.right + Input.GetAxisRaw("Vertical")*transform.forward;
        rb.AddForce(dir * runSpd, ForceMode.VelocityChange);
        //transform.position += dir * runSpd;
        foreach(Transform t in body)
        {
            t.localRotation = Quaternion.Lerp(t.localRotation, Quaternion.AngleAxis(Input.GetAxisRaw("Tilting")*tiltAng, Vector3.forward), 0.25f);
        }
    }
    // private void Update() {
    //     transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * runSpd * Time.deltaTime;
    // }
}
