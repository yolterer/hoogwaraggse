using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float maxAngle;
    public float minAngle;
    public Transform CameraAxisTransform;
    public float RotationSpeed;
    void Start()
    {
       
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);

        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }


}
