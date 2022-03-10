using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmove : MonoBehaviour
{
    public float runSpd;
    Vector3 dir;
    void Start()
    {
        
    }

    private void FixedUpdate() {
        dir = Input.GetAxisRaw("Horizontal")*transform.right + Input.GetAxisRaw("Vertical")*transform.forward;
        //dir.y = 0;
        transform.position += dir * runSpd;
    }
    // private void Update() {
    //     transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * runSpd * Time.deltaTime;
    // }
}
