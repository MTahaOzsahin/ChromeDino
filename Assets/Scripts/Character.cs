using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Health, IChildCheckList, IHitEffect ,IDeathEffect
{
    [Header("Components")]
    public Animator animator;
    public Rigidbody2D maincharacterRigibody2D;
    public SpriteRenderer maincharacterSpriteRenderer;
    public Transform maincharactertransform;

    private Transform[] ChildList;

    [SerializeField] GameObject maincharactershield;
    private GameObject ShieldClone;
    float time = 2f;
    float timer;


    public LayerMask teleportLayerMask;



    CharacterMovement characterMovement;

    public static int teleportdetection = 0;



    
   



    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
        maincharacterRigibody2D = GetComponent<Rigidbody2D>();
        maincharacterSpriteRenderer = GetComponent<SpriteRenderer>();
        maincharactertransform = GetComponent<Transform>();   
    }
   
    private void Start()
    {
        timer = Time.deltaTime;
    }
   
    void ShieldUp()
    {
        
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            
            if (timer >= time)
            {
                ShieldClone = GameObject.Instantiate(maincharactershield, maincharactertransform.position, Quaternion.identity, maincharactertransform);
                Destroy(ShieldClone, 1.7f);
                timer = 0;
            }
           
        }
    }
    public void SetCharacterState()
    {
        if (maincharacterRigibody2D.velocity.x <=  1f && maincharacterRigibody2D.velocity.x >= -1f &&
            maincharacterRigibody2D.velocity.y <= 1f && maincharacterRigibody2D.velocity.y >= -1f)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.Idle);
        }
        else if (maincharacterRigibody2D.velocity.x < 0)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.Walking);
        }
        else if (maincharacterRigibody2D.velocity.x > 0)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.Walking);
        }
        else if (maincharacterRigibody2D.velocity.y < 0)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.WalkingDown);
        }
        else if (maincharacterRigibody2D.velocity.y > 0)
        {
            characterMovement.SetMovementState(CharacterMovement.MovementStates.WalkingUp);
        }       
    }
    

    public  bool IsTeleportNear()
    {
        

        Collider2D collider = Physics2D.OverlapCircle(maincharacterSpriteRenderer.bounds.center, 0.25f);
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
    public override void TakeDamage(int damage)
    {
        HitEffect();
        base.TakeDamage(damage);
    }
    public override bool CheckIfDead()
    {
        return base.CheckIfDead();
    }
    public override void OnDeath()
    {
        if (CheckIfDead())
        {
            DeathEffect();
            Destroy(gameObject, 1.1f);
        }
    }
    public void HitEffect()
    {
        maincharactertransform.DOShakePosition(0.3f, new Vector3(0.3f, 0.1f, 0), 10, 50);
        Tween colorTween = maincharacterSpriteRenderer.DOBlendableColor(Color.red, 0.2f);
        colorTween.OnComplete(() => maincharacterSpriteRenderer.DOBlendableColor(Color.white, 0.05f));
    }

    private void FixedUpdate()
    {
        SetCharacterState();
        IsTeleportNear();
        ChildCheckList();
        OnDeath();

    }
    private void Update()
    {
        
           ShieldUp();
        
    }

    public void DeathEffect()
    {
        Tween rotateTween = maincharactertransform.DORotate(new Vector3(0, 0, 90f), 1f, RotateMode.Fast);

        Tween scaleTween = maincharactertransform.DOScale(2f, 1f);
        Tween colorTween = maincharacterSpriteRenderer.DOBlendableColor(Color.red, 0.2f);
        

        DOTween.KillAll(true, 1f);
    }
}
