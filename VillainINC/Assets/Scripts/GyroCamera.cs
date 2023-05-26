using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    [SerializeField] private bool gyroEnabled = false;
    [SerializeField] private float sensitivity = 50.0f;

    [SerializeField] private float maxVerticalRotate;
    [SerializeField] private float maxHorizontalRotate;
    
    private Gyroscope gyro;

    private float x;
    private float y;
    
    void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        
        return false;
    }
    void LateUpdate()
    {
        if (gyroEnabled)
        {
            GyroRotation();
        }
    }
    
    void GyroRotation()
    {
        x = Input.gyro.rotationRate.x;
        y = Input.gyro.rotationRate.y;
        
        var inspectorRotation = transform.rotation;

        float xFiltered = FilterGyroValues(x);
        float yFiltered = FilterGyroValues(y);
        
        if ((inspectorRotation.x < maxHorizontalRotate || yFiltered < 0)  &&
            (inspectorRotation.x > -1 * maxHorizontalRotate || yFiltered > 0))
        {
            RotateUpDown(xFiltered * sensitivity);
        }

        if ((inspectorRotation.y < maxVerticalRotate || xFiltered < 0 ) && 
            (inspectorRotation.y > -1 * maxVerticalRotate || xFiltered > 0))
        {
            RotateRightLeft(yFiltered * sensitivity);
        }
    }

    float FilterGyroValues(float axis)
    {
        if (axis < -0.1 || axis > 0.1)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }
    
    private void RotateUpDown(float axis)
    {
        transform.RotateAround(transform.position, transform.right, -axis * Time.deltaTime);
    }
    
    private void RotateRightLeft(float axis)
    {
        transform.RotateAround(transform.position, Vector3.up, -axis * Time.deltaTime);
    }
    
}