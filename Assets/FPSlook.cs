using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsLook : MonoBehaviour
{
    public float sense;
    float inputx, inputy;
    float angX, angY;
    public bool allowX, allowY;
    Quaternion orig;
    private void Start() {
        orig = transform.localRotation;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if(allowX)
            angX += Input.GetAxis("Mouse X") * sense * Time.deltaTime;
        if(allowY)
            angY -= Input.GetAxis("Mouse Y") * sense * Time.deltaTime;
            
        angY = Mathf.Clamp(angY, -85, 85);
        transform.localRotation = orig * Quaternion.AngleAxis(angX, Vector3.up) * Quaternion.AngleAxis(angY, Vector3.right);
    }
}
