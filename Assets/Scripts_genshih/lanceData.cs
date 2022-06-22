using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanceData : MonoBehaviour
{
    public Vector3 vel;
    Rigidbody rb;
    float dmg;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable() {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Invoke("disable", 8);
    }
    public void shootProjectileCaller(float t)
    {
        Invoke("shootProjectile", t);
    }
    void shootProjectile()
    {
        RipplePostProcessor.Instance.makeRipple(transform.position);
        rb.constraints = RigidbodyConstraints.None;
        rb.velocity = vel;
    }
    void disable()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("enemy")){
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        Invoke("disable", 3);
    }
}
