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
        Vector3 spawnPos;
        Physics.SphereCast(ct.position, 0.2f, ct.forward, out hitInfo, 200, 1<<6);
        spawnPos = transform.position + charaOffset * transform.up + randOffset * Random.insideUnitSphere;
        Debug.DrawRay(hitInfo.point, Vector3.up*5, Color.yellow, 3);
        Rigidbody rb = ObjPool.Instance.TakePool("iceLance01", spawnPos, Quaternion.FromToRotation(Vector3.forward, hitInfo.point - spawnPos)).GetComponent<Rigidbody>();
        rb.velocity = bulletSpeed * (hitInfo.point - spawnPos).normalized;
    }
    void elementalSkill_Long()
    {
        Transform ct = Camera.main.transform;
        Vector3 spawnPos, landPos;
        Physics.SphereCast(ct.position, 0.2f, ct.forward, out hitInfo, 200, 1<<6);
        for(int i = 0; i < 6; i++)
        {
            spawnPos = hitInfo.point + 40 * transform.up + randOffset * Random.onUnitSphere;
            landPos = hitInfo.point + randOffset * Random.insideUnitSphere;
            Debug.DrawRay(landPos, Vector3.up*5, Color.yellow, 3);
            Rigidbody rb = ObjPool.Instance.TakePool("iceLance01", spawnPos, Quaternion.FromToRotation(Vector3.forward, landPos - spawnPos)).GetComponent<Rigidbody>();
            rb.velocity = bulletSpeed * (landPos - spawnPos).normalized;
        }
    }
}
