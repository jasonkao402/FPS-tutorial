using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
	public Rigidbody rb;
	public float sensitivityX, sensitivityY;
	public float minX, maxX, minY, maxY;
	float rotationX, rotationY;
	Quaternion originalRotation, xQuaternion, yQuaternion;
	void Start ()
    {
        // Make the rigid body not change rotation
		Cursor.lockState = CursorLockMode.Locked;
		rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.freezeRotation = true;
        originalRotation = transform.localRotation;
    }
	void Update ()
	{
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

		rotationX = ClampAngle (rotationX, minX, maxX);
		rotationY = ClampAngle (rotationY, minY, maxY);

		xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
		yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left);
		transform.localRotation = originalRotation * xQuaternion * yQuaternion;
	}
    
    public static float ClampAngle (float angle, float min, float max)
    {
        return Mathf.Clamp (Mathf.Repeat(angle+180f, 360f)-180f, min, max);
	}
}