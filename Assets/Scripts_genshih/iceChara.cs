using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceChara : MonoBehaviour
{
    public GameObject projectile;
    public float longPress, charaOffset, randOffset, bulletSpeed;
    float pressA, pressB;
	RaycastHit hitInfo;
    void Start()
    {
        pressA = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            pressB = Time.time - pressA;
            Debug.Log(pressB > longPress ? "long" : "short");

            if(pressB > longPress)
                elementalSkill_Long();
            else
                elementalSkill_Short();
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            pressA = Time.time;
        }
    }
    void elementalSkill_Short()
    {
        Transform ct = Camera.main.transform;
        Vector3 spawnPos, castPoi, direction;
        if(Physics.SphereCast(ct.position, 0.2f, ct.forward, out hitInfo, Camera.main.farClipPlane, 1<<6))
            castPoi = hitInfo.point;
        else
            castPoi = transform.position + ct.forward * Camera.main.farClipPlane;
        for(int i = -60; i <= 60; i+=120)
        {
            spawnPos = transform.position + charaOffset * (transform.up + (Quaternion.AngleAxis(i, Vector3.up) * transform.forward));
            direction = castPoi - spawnPos;
            ObjPool.Instance.TakePool("summon", spawnPos, Quaternion.FromToRotation(Vector3.forward, direction)).GetComponentInChildren<Rigidbody>();
            lanceData ld = ObjPool.Instance.TakePool("iceLance01", spawnPos, Quaternion.FromToRotation(Vector3.forward, direction)).GetComponentInChildren<lanceData>();
            ld.vel = bulletSpeed * direction.normalized;
            ld.shootProjectileCaller(Random.Range(.2f, .4f));
        }
    }
    void elementalSkill_Long()
    {
        Transform ct = Camera.main.transform;
        Vector3 spawnPos, castPoi, landPos, direction;
        if(Physics.SphereCast(ct.position, 0.2f, ct.forward, out hitInfo, Camera.main.farClipPlane, 1<<6))
            castPoi = hitInfo.point;
        else
            castPoi = transform.position + ct.forward * Camera.main.farClipPlane*.1f;
        
        for(int i = 0, j = 0; i < 360; i+=60, j++)
        {
            spawnPos = castPoi + 8 * Vector3.up * randOffset;
            landPos =  castPoi + Quaternion.AngleAxis(i, Vector3.up) * Vector3.forward * randOffset;
            direction = landPos - spawnPos;
            lanceData ld = ObjPool.Instance.TakePool("iceLance01", spawnPos, Quaternion.FromToRotation(Vector3.forward, direction)).GetComponentInChildren<lanceData>();
            ld.vel = bulletSpeed * direction.normalized;
            ld.shootProjectileCaller(j*0.1f);
        }
    }
}
