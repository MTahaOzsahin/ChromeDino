using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IChildCheckList
{
    [Header("Components")]
    public Animator animator;
    public Rigidbody2D Charachterrb2D;
    public SpriteRenderer spriteRenderer;
    public Transform maincharactertransform;

    private Transform[] ChildList;

  


    public LayerMask teleportLayerMask;



    CharacterMovement characterMovement;

    public static int teleportdetection = 0;



    
   



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
    

    public  bool IsTeleportNear()
    {
        

        Collider2D collider = Physics2D.OverlapCircle(spriteRenderer.bounds.center, 0.25f);
        if (collider.CompareTag("teleportblue1"))
        {
           
            teleportdetection = 1;            
            return true;
        }
        else if (collider.CompareTag("teleportblue2"))
        {
           
            teleportdetection = 2;
            return true;
        }
        else if (collider.CompareTag("teleportblue3"))
        {
           
            teleportdetection = 3;
            return true;
        }
        else if (collider.CompareTag("teleportblue4"))
        {
            
            teleportdetection = 4;
            return true;
        }
        else if (collider.CompareTag("teleportred1"))
        {
            
            teleportdetection = 5;
            return true;
        }
        else if (collider.CompareTag("teleportred3"))
        {
            
            teleportdetection = 7;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChildCheckList()
    {
        ChildList = new Transform[transform.childCount];
        int i = 0;
        foreach (Transform child in transform)
        {
            ChildList[i] = child;
            i++;
        }
      //  Debug.Log("MainCharacter have " + i + " items");
        if (ChildList.Length > 0)
        {
            for (int a = 0; a < ChildList.Length; a++)
            {
                //Debug.Log(ChildList[a].name);
            }
        }


    }

    

    private void FixedUpdate()
    {
        SetCharacterState();
        IsTeleportNear();
        ChildCheckList();
        
       
       
    }
    private void Update()
    {
       
    }
}
