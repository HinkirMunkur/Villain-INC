using UnityEngine;
using System.Collections;
using Munkur;

public class HarpoonBasic : ClickableTrapBasic
{
    [SerializeField] private SpearBasic spearBasic;
    [SerializeField] private Vector2 forceToSpear;
    [SerializeField] private bool isRotating;
    [SerializeField] private float angleToRotate;
    
    private float currentAngle;
    private Coroutine StopRotation;

    private void Awake()
    {
        spearBasic.SetSpearStatic();
        spearBasic.DisableSpearSlayCollider();
    
        if (isRotating) 
        {
            StopRotation = StartCoroutine(RotateHarpoon());
        }
    }

    public override void TrapClicked()
    {
        AudioManager.Instance.PlaySoundEffect("Spear");

        if (isRotating) 
        {
            StopCoroutine(StopRotation);

            forceToSpear.x = Mathf.Cos(Mathf.Deg2Rad * (currentAngle + 90)) * 10000;
            forceToSpear.y = Mathf.Sin(Mathf.Deg2Rad * (currentAngle + 90)) * 10000;
        }

        spearBasic.SetSpearDynamic();
        spearBasic.EnableSpearSlayCollider();
        StartCoroutine(spearBasic.AddForceUntilCrush(forceToSpear));
    }

    public IEnumerator RotateHarpoon() 
    {
        float initialRotation = transform.eulerAngles.z;
        
        while (true) 
        {
            currentAngle = transform.eulerAngles.z;

            while (currentAngle < initialRotation + angleToRotate) 
            {
                transform.eulerAngles = Vector3.forward * (currentAngle + 1);
                currentAngle = transform.eulerAngles.z;

                yield return new WaitForSeconds(0.01f);
            }
            while (currentAngle >= initialRotation) 
            {
                transform.eulerAngles = Vector3.forward * (currentAngle - 1);
                currentAngle = transform.eulerAngles.z;

                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
