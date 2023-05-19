using System;
//using UnityEditor;
using UnityEngine;

public class CameraMovementWithAccelerometer : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float maxVerticalRotate;
    [SerializeField] private float maxHorizontalRotate;

    [SerializeField] private float rotateSpeed;

    [SerializeField] private float rotationTrashHold;

    private void Start()
    {
        Input.gyro.enabled = true;
    }
    
    /*
    private void LateUpdate()
    {
        var gyroVector = Input.gyro.rotationRateUnbiased;
        
        var rotX = gyroVector.x * rotateSpeed * Time.deltaTime;
        var rotY = gyroVector.y * rotateSpeed * Time.deltaTime;

        if (Math.Abs(rotX) > rotationTrashHold || Math.Abs(rotY) > rotationTrashHold)
        {
            var inspectorRotation = TransformUtils.GetInspectorRotation(mainCamera.transform);
        
            if ((inspectorRotation.x < maxVerticalRotate || rotX < 0) &&
                (inspectorRotation.x > -1 * maxVerticalRotate || rotX > 0))
            {
                mainCamera.transform.Rotate(rotX, 0f, 0f);
            }

            if ((inspectorRotation.y < maxHorizontalRotate || rotY < 0) && 
                (inspectorRotation.y > -1 * maxHorizontalRotate || rotY > 0))
            {
                mainCamera.transform.Rotate(0f, rotY, 0f);
            }
        
            var inspectorRotationUpdate = TransformUtils.GetInspectorRotation(mainCamera.transform);

            mainCamera.transform.eulerAngles = new Vector3(inspectorRotationUpdate.x, inspectorRotationUpdate.y, 0f);    
        }
        
    }
    */
}
