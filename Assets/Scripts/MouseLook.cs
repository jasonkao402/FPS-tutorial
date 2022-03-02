using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public Rigidbody rb;
	public float sensitivityX = 15f;
	public float sensitivityY = 15f;
	public float minimumX = -360f;
	public float maximumX = 360f;
	public float minimumY = -60f;
	public float maximumY = 60f;
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
		// Read the mouse input axis
		switch (axes)
		{
		case RotationAxes.MouseXAndY:
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			xQuaternion = Quaternion.AngleAxis ( rotationX, Vector3.up);
			yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
			break;

		case RotationAxes.MouseX:
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
			break;

		case RotationAxes.MouseY:
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = ClampAngle (rotationY, minimumY, maximumY);
			yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			transform.localRotation = originalRotation * yQuaternion;
			break;
		}
	}
    
    public static float ClampAngle (float angle, float min, float max)
    {
        return Mathf.Clamp (Mathf.Repeat(angle+180f, 360f)-180f, min, max);
	}
}