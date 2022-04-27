using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunHandle : MonoBehaviour
{
    public GameObject bullet;
    public Transform currentGun;
    public float cdMax, cdNow, bulletforce, offset;
    float recoilZ;
    public Vector3 recoilVec;
    public float[] zoom = new float[2];
    public Transform[] adsPos = new Transform[2];
    Camera cam;
    fpsLook fpsLook;
    public AudioClip sfx;
    private void Start() {
        fpsLook = GetComponent<fpsLook>();
        cdNow = cdMax;
        cam = Camera.main;
    }
    void Update()
    {
        cdNow -= Time.deltaTime;
        if(cdNow < 0 && Input.GetMouseButton(0))
        {
            Rigidbody bulletrb = ObjPool.Instance.TakePool("bullet", transform.position + transform.forward * offset, transform.rotation).GetComponent<Rigidbody>();
            bulletrb.velocity = currentGun.forward * bulletforce;
            SoundManager.instance.RandomizeSfx(sfx);
            cdNow = cdMax;
            recoilZ += recoilVec.z;
            currentGun.localRotation = Quaternion.Slerp(currentGun.localRotation, 
            Quaternion.Euler(
                recoilVec.y*Mathf.PerlinNoise(Time.time, 0f), 
                recoilVec.x*(Mathf.PerlinNoise(Time.time, 0f)-0.5f),
                0f)
            , 0.5f);
        }
    }
    private void FixedUpdate() {
        recoilZ = Mathf.Lerp(0, recoilZ, 0.25f);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom[Input.GetMouseButton(1) ? 1 : 0], 0.25f);
        currentGun.localPosition = Vector3.Lerp(currentGun.localPosition, adsPos[Input.GetMouseButton(1) ? 1 : 0].localPosition + recoilZ * Vector3.back, 0.25f);
    }
}
