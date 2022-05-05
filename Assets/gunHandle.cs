using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gunHandle : MonoBehaviour
{
    public GameObject bullet;
    public Transform currentGun, muzzelPos;
    public float cdMax, cdNow, bulletforce, offset, sway;
    public Vector3 recoilAttr;
    Vector3 swayVec, recoilVec;
    public float[] zoom = new float[2];
    public Transform[] adsPos = new Transform[2];
    Camera cam;
    fpsLook fpsLook;
    public AudioClip sfx;
    public Image hitMarker;
    static Color white0 = new Color(1, 1, 1, 0);
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
            GameObject bulletrb = ObjPool.Instance.TakePool("bullet", transform.position + transform.forward * offset, transform.rotation);
            ObjPool.Instance.TakePool("muzzleFlash", muzzelPos.position, transform.rotation);
            bulletrb.GetComponent<Rigidbody>().velocity = currentGun.forward * bulletforce;
            bulletrb.GetComponent<bulletData>().projtileSource = this;
            SoundManager.instance.RandomizeSfx(sfx);
            cdNow = cdMax; 
            recoilVec += new Vector3(
                recoilAttr.x*(Mathf.PerlinNoise(0f, Time.time)-0.5f), 
                recoilAttr.y*(Mathf.PerlinNoise(Time.time, 0f)),
                recoilAttr.z);
            currentGun.localRotation = 
                Quaternion.AngleAxis(recoilVec.x, Vector3.up)*
                Quaternion.AngleAxis(recoilVec.y, Vector3.right);
        }
        swayVec = new Vector3(Input.GetAxisRaw("Mouse X")*sway, Input.GetAxisRaw("Mouse Y")*sway, -recoilVec.z);
    }
    private void FixedUpdate() {
        hitMarker.color = Color.Lerp(hitMarker.color, white0, 0.1f);
        recoilVec = Vector3.Lerp(recoilVec, Vector3.zero, 0.2f);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom[Input.GetMouseButton(1) ? 1 : 0], 0.25f);
        currentGun.localPosition = Vector3.Lerp(currentGun.localPosition, adsPos[Input.GetMouseButton(1) ? 1 : 0].localPosition - swayVec, 0.25f);
        fpsLook.offset = currentGun.localRotation = Quaternion.Slerp(currentGun.localRotation, Quaternion.identity, 0.1f);
    }
    public void hitFeedback(){
        hitMarker.color = Color.white;
    }
}
