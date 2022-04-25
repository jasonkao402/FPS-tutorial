using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject bullet;
    public float cdMax, cdNow, bulletforce, offset;
    private void Start() {
        cdNow = cdMax;
    }
    void Update()
    {
        cdNow -= Time.deltaTime;
        if(cdNow < 0 && Input.GetMouseButton(0))
        {
            Rigidbody bulletrb = Instantiate(bullet, transform.position + transform.forward * offset, transform.rotation).GetComponent<Rigidbody>();
            bulletrb.velocity = transform.forward * bulletforce;
            cdNow = cdMax;
        }
    }
}
