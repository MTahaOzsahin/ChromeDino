using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    [SerializeField] Animator EnemyAnimator;
    [SerializeField] GameObject EnemyGameObject;
    [SerializeField] Rigidbody2D EnemyRigiBody2D;
    [SerializeField] SpriteRenderer EnemySpriteRenderer;
    [SerializeField] LayerMask MainCharacterLayerMask;

    [SerializeField] GameObject MainCharacterGameObject;
    
 
    [SerializeField] enum EnemyMovementState { idle,walking};
    private EnemyMovementState enemymovementstate;
   
    private void Awake()
    {
        EnemyAnimator = GetComponent<Animator>();      
        EnemyRigiBody2D = GetComponent<Rigidbody2D>();
    }
   
    private void PlayAnimationBasedOnState()
    {
        switch (enemymovementstate)
        {
            case EnemyMovementState.idle:
                PlayIdleAnim();
                break;
            case EnemyMovementState.walking:
                PlayWalkingAnim();
                break;
            default:
                break;
        }
    }
    void PlayIdleAnim()
    {
        EnemyAnimator.SetBool("IsWalking", false);
    }
    void PlayWalkingAnim()
    {
        EnemyAnimator.SetBool("IsWalking", true);
    }
    void SetMovementState (EnemyMovementState enemyMovementState)
    {
        enemymovementstate = enemyMovementState;
    }
    void SetEnemyState()
    {
       if (EnemyRigiBody2D.velocity.x < 1 && EnemyRigiBody2D.velocity.x > -1)
        {
            SetMovementState(EnemyMovementState.idle);
        }
        else
        {
            SetMovementState(EnemyMovementState.walking);
        }
        
    }

    void enemyMovement()
    {
        Collider2D collider2D = Physics2D.OverlapBox(EnemySpriteRenderer.bounds.center,new Vector2 (15f,1f), 0f, MainCharacterLayerMask);
        if (collider2D == null)
        {
            return;
        }
           
        else
        {
            if (EnemyGameObject.transform.position.x > MainCharacterGameObject.transform.position.x)
            {
                EnemyGameObject.transform.eulerAngles = new Vector2(0, 180);
                EnemyRigiBody2D.velocity = new Vector2(-1, 0);               
            }
            else
            {
                EnemyGameObject.transform.eulerAngles = new Vector2(0, 0);
                EnemyRigiBody2D.velocity = new Vector2(1, 0);               
            }
        }
        
    }
    
    private void Update()
    {
        enemyMovement();
        SetEnemyState();
        
    }
    private void FixedUpdate()
    {
        PlayAnimationBasedOnState();
    }
}
