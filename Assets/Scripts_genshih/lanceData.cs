using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanceData : MonoBehaviour
{
    Rigidbody rb;
    float dmg;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable() {
        rb.constraints = RigidbodyConstraints.None;
        Invoke("disable", 5);
    }
    void disable()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("enemy")){
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        Invoke("disable", 2);
    }
}
