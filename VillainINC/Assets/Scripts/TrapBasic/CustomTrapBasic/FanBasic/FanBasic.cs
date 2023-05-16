using System.Collections.Generic;
using UnityEngine;

public class FanBasic : ClickableTrapBasic
{
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private List<ParticleSystem> fanParticleList;

    [SerializeField] private Vector2 fanForceVector;
    public Vector2 FanForceVector => fanForceVector;
    
    private bool isOpen = false;
    public override void TrapClicked()
    {
        if (isOpen)
        {
            isOpen = false;
            boxCollider2D.enabled = false;
            foreach (var fanParticle in fanParticleList)
            {
                fanParticle.Stop();
            }   
        }
        else
        {
            isOpen = true;
            boxCollider2D.enabled = true;
            foreach (var fanParticle in fanParticleList)
            {
                fanParticle.Play();
            }
        }
    }
}
