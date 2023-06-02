using System.Collections.Generic;
using Munkur;
using UnityEngine;

public class FanBasic : ClickableTrapBasic
{
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private List<ParticleSystem> fanParticleList;

    [SerializeField] private Vector2 fanForceVector;
    public Vector2 FanForceVector => fanForceVector;

    [SerializeField] private Animator animator;
    
    private bool isOpen = false;
    public override void TrapClicked()
    {
        if (isOpen)
        {
            AudioManager.Instance.StopMusic();
            
            isOpen = false;
            boxCollider2D.enabled = false;
            animator.enabled = false;
            foreach (var fanParticle in fanParticleList)
            {
                fanParticle.Stop();
            }   
        }
        else
        {
            AudioManager.Instance.PlaySoundEffect("Fan");
            
            isOpen = true;
            boxCollider2D.enabled = true;
            animator.enabled = true;
            foreach (var fanParticle in fanParticleList)
            {
                fanParticle.Play();
            }
        }
    }
}
