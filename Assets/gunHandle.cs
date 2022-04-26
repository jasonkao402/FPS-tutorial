using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunHandle : MonoBehaviour
{
    public GameObject bullet;
    public Transform currentGun;
    public float cdMax, cdNow, bulletforce, offset;
    public float[] zoom = new float[2];
    public Transform[] adsPos = new Transform[2];
    Camera cam;
    private void Start() {
        cdNow = cdMax;
        cam = Camera.main;
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
    private void FixedUpdate() {
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom[Input.GetMouseButton(1) ? 1 : 0], 0.25f);
        currentGun.localPosition = Vector3.Lerp(currentGun.localPosition, adsPos[Input.GetMouseButton(1) ? 1 : 0].localPosition, 0.25f);
    }
}
