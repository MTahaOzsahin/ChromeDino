using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D maincharacterrb2d;
    public SpriteRenderer maincharactersr;
    public Animator animator;
    public GameObject teleport1;
    public GameObject teleport2;
    public GameObject teleport3;
    public GameObject teleport4;
    public LayerMask ladderLayerMask;
    public LayerMask teleportLayerMask;


    [Header("Variables")]
   public float walkingspeed;
   public float runningspeed;

    [Header("AnimationController")]
    public MovementStates movementState;
    private CharacterAnimationController animController;
    
    public enum MovementStates
    {
        Idle,
        Walking,
        WalkingUp,
        WalkingDown,
    }


    private void Awake()
    {
        maincharacterrb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animController = GetComponent<CharacterAnimationController>();
        maincharactersr = GetComponent<SpriteRenderer>();
    }

    void Charactermovement()
    {
        
        maincharacterrb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (!IsClimbAvaible())
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
        }
        else
        {
            Physics2D.gravity = new Vector2(0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {               
                maincharacterrb2d.velocity = new Vector2(runningspeed, 0f);
                transform.eulerAngles = new Vector2(0, 0);
                
            }
            else
            {               
                maincharacterrb2d.velocity = new Vector2(walkingspeed, 0f);
                transform.eulerAngles = new Vector2(0, 0);
            }
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {                            
                maincharacterrb2d.velocity = new Vector2(-runningspeed, 0f);
                transform.eulerAngles = new Vector2(0, 180);
            }
            else
            {               
                maincharacterrb2d.velocity = new Vector2(-walkingspeed, 0f);
                transform.eulerAngles = new Vector2(0, 180);
            }
            
        }
        
        else if (Input.GetKey(KeyCode.W) && IsClimbAvaible())
        {
            
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                maincharacterrb2d.velocity = new Vector2(0f, runningspeed);
            }
            else
            {               
                maincharacterrb2d.velocity = new Vector2(0f, walkingspeed);
            }
        }
        else if (Input.GetKey(KeyCode.S) && IsClimbAvaible())
        {
            
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
            {
                maincharacterrb2d.velocity = new Vector2(0f, -runningspeed);
            }
            else
            {               
                maincharacterrb2d.velocity = new Vector2(0f, -walkingspeed);
            }
        }
        
        
    }
    //Teleporttain Devam edielcek
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if ( collision.CompareTag("teleportblue2") && IsTeleport())
        {
            maincharacterrb2d.transform.position = new Vector3(teleport1.transform.position.x - 1, teleport1.transform.position.y,
                maincharacterrb2d.transform.position.z);
        }
        else  if (IsTeleport() && Input.GetKeyDown(KeyCode.Space))
        {
            maincharacterrb2d.transform.position = new Vector3(teleport2.transform.position.x + 1, teleport2.transform.position.y,
                maincharacterrb2d.transform.position.z);          
        }
        /*
        else if (collision.CompareTag("teleportblue1") && IsTeleport())
        {
            maincharacterrb2d.transform.position = new Vector3(teleport2.transform.position.x + 1, teleport2.transform.position.y,
                maincharacterrb2d.transform.position.z);
        }
        */
        else if (collision.CompareTag("teleportblue3"))
        {
            maincharacterrb2d.transform.position = new Vector3(teleport4.transform.position.x + 1, teleport4.transform.position.y,
                maincharacterrb2d.transform.position.z);
        }
        else if (collision.CompareTag("teleportblue4"))
        {
            maincharacterrb2d.transform.position = new Vector3(teleport3.transform.position.x - 1, teleport3.transform.position.y,
                maincharacterrb2d.transform.position.z);
        }
        

    }
   
    public bool IsClimbAvaible()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(maincharactersr.bounds.center, maincharactersr.bounds.size, 0f,
            Vector2.right, 0.25f, ladderLayerMask);
        

        return raycastHit2D.collider != null;
    }
    public bool IsTeleport()
    {
        RaycastHit2D raycastHitTeleport2D = Physics2D.BoxCast(maincharactersr.bounds.center, maincharactersr.bounds.size, 0f,
            Vector2.right, 0.25f, teleportLayerMask);

        return raycastHitTeleport2D.collider != null;
    }
    
    public void PlayAnimationBasedOnState()
    {
        switch (movementState)
        {
            case MovementStates.Idle:
                animController.PlayIdleAnim();
                break;         
            case MovementStates.Walking:
                animController.PlayWalkingAnim();
                break;           
            case MovementStates.WalkingUp:
                animController.PlayWalkingUpAnim();
                break;
            case MovementStates.WalkingDown:
                animController.PlayWalkingDownAnim();
                break;
            default:
                break;
        }
    }
    public void SetMovementState(MovementStates movementStates)
    {
        movementState = movementStates;
    }
    private void FixedUpdate()
    {
        Charactermovement();
        PlayAnimationBasedOnState();
    }
}
