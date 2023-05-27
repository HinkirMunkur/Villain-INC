using UnityEngine;
using System;

public class CameraMovementWithAccelerometer : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float maxVerticalRotate;
    [SerializeField] private float maxHorizontalRotate;

    [SerializeField] private float rotateSpeed;

    [SerializeField] private float rotationTrashHold;

    private Vector3 lastCameraRotation;

    private void Start()
    {
        lastCameraRotation = mainCamera.transform.eulerAngles;
        Input.gyro.enabled = true;
    }

    private void LateUpdate()
    {
        var gyroVector = Input.gyro.rotationRateUnbiased;
        
        var rotX = gyroVector.x * rotateSpeed * Time.deltaTime;
        var rotY = gyroVector.y * rotateSpeed * Time.deltaTime;

        if (Math.Abs(rotX) > rotationTrashHold || Math.Abs(rotY) > rotationTrashHold)
        {
            Debug.Log("x:" + rotX + "y:" + rotY);
            var inspectorRotation = mainCamera.transform.eulerAngles;
        
            if ((inspectorRotation.x < maxVerticalRotate || rotX < 0)  &&
                (inspectorRotation.x > -1 * maxVerticalRotate || -1 * rotX > 0))
            {
                lastCameraRotation += Vector3.right * rotX;
            }

            if ((inspectorRotation.y < maxHorizontalRotate || rotY < 0)  && 
                (inspectorRotation.y > -1 * maxHorizontalRotate || -1 * rotY > 0))
            {
                lastCameraRotation += Vector3.up * rotY;
            }

            mainCamera.transform.eulerAngles = lastCameraRotation;

            //var inspectorRotationUpdate = mainCamera.transform.rotation;

            //mainCamera.transform.eulerAngles = new Vector3(inspectorRotationUpdate.x, inspectorRotationUpdate.y, 0f);    
        }
        
    }
    
}
