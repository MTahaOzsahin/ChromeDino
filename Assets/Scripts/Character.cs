using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Components")]
    public Animator animator;
    public Rigidbody2D Charachterrb2D;
    public SpriteRenderer spriteRenderer;


    CharacterMovement characterMovement;


    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
        Charachterrb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   public void SetCharacterState()
    {
        if (Charachterrb2D.velocity.x <=  0.01f && Charachterrb2D.velocity.x >= -0.01f &&
            Charachterrb2D.velocity.y <= 0.01f && Charachterrb2D.velocity.y >= -0.01f)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.Idle);
        }
        else if (Charachterrb2D.velocity.x < 0)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.Walking);
        }
        else if (Charachterrb2D.velocity.x > 0)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.Walking);
        }
        else if (Charachterrb2D.velocity.y < 0)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.WalkingDown);
        }
        else if (Charachterrb2D.velocity.y > 0)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.WalkingUp);
        }       
    }
    private void FixedUpdate()
    {
        SetCharacterState();
    }
}
