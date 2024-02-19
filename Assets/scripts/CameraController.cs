using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minAngle;
    public float maxAngle;
    public Transform CameraAxisTransform;
    public float rotationSpeed;
   private Vector3 lastMousePosition;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        Vector3 delta = Input.mousePosition - lastMousePosition;

        if (delta.magnitude >  0)
        {
            transform.Rotate(0, delta.x * rotationSpeed * Time.deltaTime,  0);
            var currentAngleX = CameraAxisTransform.localEulerAngles.x;
            var newAngleX = currentAngleX - delta.y * rotationSpeed * Time.deltaTime;
            newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
            CameraAxisTransform.localEulerAngles = new Vector3(newAngleX,  0,  0);
        }

        lastMousePosition = Input.mousePosition;
    }


}
