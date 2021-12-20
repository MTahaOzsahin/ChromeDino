using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D maincharacterrb2d;
    public Animator animator;
    public GameObject teleport1;
    public GameObject teleport2;
    public GameObject teleport3;
    public GameObject teleport4;


    [Header("Variables")]
   public float walkingspeed;
   public float runningspeed;


    private void Awake()
    {
        maincharacterrb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }

    void Charactermovement()
    {
        
        maincharacterrb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
                maincharacterrb2d.velocity = new Vector2(runningspeed, 0f);
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
                maincharacterrb2d.velocity = new Vector2(walkingspeed, 0f);
                transform.eulerAngles = new Vector2(0, 0);
            }
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);               
                maincharacterrb2d.velocity = new Vector2(-runningspeed, 0f);
                transform.eulerAngles = new Vector2(0, 180);
            }
            else
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
                maincharacterrb2d.velocity = new Vector2(-walkingspeed, 0f);
                transform.eulerAngles = new Vector2(0, 180);
            }
            
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("teleportblue2"))
        {
            maincharacterrb2d.transform.position = new Vector3(teleport1.transform.position.x - 1, teleport1.transform.position.y,
                maincharacterrb2d.transform.position.z);
        }
        else  if (collision.CompareTag("teleportblue1"))
        {
            maincharacterrb2d.transform.position = new Vector3(teleport2.transform.position.x + 1, teleport2.transform.position.y,
                maincharacterrb2d.transform.position.z);          
        }
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
    

    private void FixedUpdate()
    {
        Charactermovement();
    }
}
