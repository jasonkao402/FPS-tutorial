using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qtest : MonoBehaviour
{
    public float rotateXSpeed;
    public float rotateYSpeed;

    Quaternion orig;
    private void Start() {
        orig = transform.localRotation;
    }

    void Update()
    {

        transform.localRotation *= Quaternion.AngleAxis(rotateXSpeed * Time.deltaTime, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotateYSpeed * Time.deltaTime, Vector3.right);
    }
}
