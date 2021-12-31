using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Components")]
    public Animator animator;
    public Rigidbody2D Charachterrb2D;
    public SpriteRenderer spriteRenderer;
    public Inventory inventory;
    public Transform maincharactertransform;


    CharacterMovement characterMovement;


    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
        Charachterrb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        maincharactertransform = GetComponent<Transform>();
    }

   public void SetCharacterState()
    {
        if (Charachterrb2D.velocity.x <=  1f && Charachterrb2D.velocity.x >= -1f &&
            Charachterrb2D.velocity.y <= 1f && Charachterrb2D.velocity.y >= -1f)
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            inventory.AddItem(other.GetComponent<Item>());
        }
    }
    private void FixedUpdate()
    {
        SetCharacterState();
    }
}
