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

    public LayerMask teleportLayerMask;


    CharacterMovement characterMovement;


    public int a = 0;

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

    public bool IsTeleportNear()
    {
        //buradan devam edielcek

        Collider2D collider = Physics2D.OverlapCircle(spriteRenderer.bounds.center, 0.25f, teleportLayerMask);
        if (collider.CompareTag("teleportblue1") && collider != null)
        {
            a = 1;
            return true;
        }
        else
        {
            return false;
        }
    }


   
    private void FixedUpdate()
    {
        SetCharacterState();
        if (IsTeleportNear())
        {
            Debug.Log("is near" + a);
        }
    }
}
