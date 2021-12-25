using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayIdleAnim()
    {
        
        animator.SetBool("isWalking", false);
        animator.SetBool("isWalkingUp", false);
        animator.SetBool("isWalkingDown", false);
    }
    public void PlayRunnigAnim() //Will Not inclueded rightnow
    {
        
        animator.SetBool("isWalking", false);
        animator.SetBool("isWalkingUp", false);
        animator.SetBool("isWalkingDown", false);
    }
    public void PlayWalkingAnim()
    {
        
        animator.SetBool("isWalking", true);
        animator.SetBool("isWalkingUp", false);
        animator.SetBool("isWalkingDown", false);
    }
    
    public void PlayWalkingUpAnim()
    {
        
        animator.SetBool("isWalking", true);
        animator.SetBool("isWalkingUp", true);
        animator.SetBool("isWalkingDown", false);
    }
    public void PlayWalkingDownAnim()
    {
        
        animator.SetBool("isWalking", true);
        animator.SetBool("isWalkingUp", false);
        animator.SetBool("isWalkingDown", true);
    }
}
