using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{
    [SerializeField] Animator EnemyAnimator;
    [SerializeField] GameObject EnemyGameObject;
    [SerializeField] Rigidbody2D EnemyRigiBody2D;
    [SerializeField] SpriteRenderer EnemySpriteRenderer;
    [SerializeField] Transform EnemyTransform;
    [SerializeField] LayerMask MainCharacterLayerMask;

    [SerializeField] GameObject MainCharacterGameObject;
    [SerializeField] GameObject EnemyShot;
    private GameObject EnemyShotClone;

    float time = 3f;
    float timer;

    public enum EnemyType { yellow, grey, greyar,greenar};
    public EnemyType enemytype;    
 
    [SerializeField] enum EnemyMovementState { idle,walking};
    private EnemyMovementState enemymovementstate;
   
    private void Awake()
    {
        EnemyAnimator = GetComponent<Animator>();      
        EnemyRigiBody2D = GetComponent<Rigidbody2D>();
        EnemyTransform = GetComponent<Transform>();
    }
    private void Start()
    {
        timer = Time.deltaTime;
    }
    public override void TakeDamage(int damage)
    {
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
            
            Destroy(this.gameObject);
        }
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
        timer += Time.deltaTime;
        Collider2D collider2D = Physics2D.OverlapBox(EnemySpriteRenderer.bounds.center,new Vector2 (15f,1f), 0f, MainCharacterLayerMask);
        if (collider2D == null)
        {
            return;
        }
           
        else
        {
            switch (enemytype)
            {
                case EnemyType.yellow:
                    if (EnemyGameObject.transform.position.x > MainCharacterGameObject.transform.position.x)
                    {
                        if (timer >= time)
                        {
                            EnemyShotClone = GameObject.Instantiate(EnemyShot, 
                                new Vector3(EnemyTransform.position.x-1f, EnemyTransform.position.y,EnemyTransform.position.z)
                                , Quaternion.identity, EnemyTransform);
                            EnemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                            Destroy(EnemyShotClone, 2f);
                            timer = 0;
                        }
                    }
                    else
                    {
                        if (timer >= time)
                        {
                            EnemyShotClone = GameObject.Instantiate(EnemyShot,
                                new Vector3(EnemyTransform.position.x + 1f, EnemyTransform.position.y, EnemyTransform.position.z)
                                , Quaternion.identity, EnemyTransform);
                            EnemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                            Destroy(EnemyShotClone, 2f);
                            timer = 0;
                        }
                    }
                    

                    break;
                case EnemyType.grey:
                    if (EnemyGameObject.transform.position.x > MainCharacterGameObject.transform.position.x)
                    {
                        if (timer >= time)
                        {
                            EnemyShotClone = GameObject.Instantiate(EnemyShot,
                                new Vector3(EnemyTransform.position.x - 1f, EnemyTransform.position.y, EnemyTransform.position.z)
                                , Quaternion.identity, EnemyTransform);
                            EnemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                            Destroy(EnemyShotClone, 2f);
                            timer = 0;
                        }
                    }
                    else
                    {
                        if (timer >= time)
                        {
                            EnemyShotClone = GameObject.Instantiate(EnemyShot,
                                new Vector3(EnemyTransform.position.x + 1f, EnemyTransform.position.y, EnemyTransform.position.z)
                                , Quaternion.identity, EnemyTransform);
                            EnemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                            Destroy(EnemyShotClone, 2f);
                            timer = 0;
                        }
                    }
                    break;
                case EnemyType.greyar:
                    if (EnemyGameObject.transform.position.x > MainCharacterGameObject.transform.position.x)
                    {
                        EnemyGameObject.transform.eulerAngles = new Vector2(0, 180);
                        EnemyRigiBody2D.velocity = new Vector2(-1, 0);
                        if (timer >= time)
                        {
                            EnemyShotClone = GameObject.Instantiate(EnemyShot,
                                new Vector3(EnemyTransform.position.x - 1f, EnemyTransform.position.y, EnemyTransform.position.z)
                                , Quaternion.identity, EnemyTransform);
                            EnemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                            Destroy(EnemyShotClone, 2f);
                            timer = 0;
                        }


                    }
                    else
                    {
                        EnemyGameObject.transform.eulerAngles = new Vector2(0, 0);
                        EnemyRigiBody2D.velocity = new Vector2(1, 0);
                        if (timer >= time)
                        {
                            EnemyShotClone = GameObject.Instantiate(EnemyShot,
                                 new Vector3(EnemyTransform.position.x + 1f, EnemyTransform.position.y, EnemyTransform.position.z)
                                 , Quaternion.identity, EnemyTransform);
                            EnemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                            Destroy(EnemyShotClone, 2f);
                            timer = 0;
                        }
                    }
                    break;
                case EnemyType.greenar:
                    if (EnemyGameObject.transform.position.x > MainCharacterGameObject.transform.position.x)
                    {
                        EnemyGameObject.transform.eulerAngles = new Vector2(0, 180);
                        EnemyRigiBody2D.velocity = new Vector2(-1, 0);
                        if (timer >= time)
                        {
                            EnemyShotClone = GameObject.Instantiate(EnemyShot,
                                new Vector3(EnemyTransform.position.x - 1f, EnemyTransform.position.y, EnemyTransform.position.z)
                                , Quaternion.identity, EnemyTransform);
                            EnemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                            Destroy(EnemyShotClone, 2f);
                            timer = 0;
                        }
                    }
                    else
                    {
                        EnemyGameObject.transform.eulerAngles = new Vector2(0, 0);
                        EnemyRigiBody2D.velocity = new Vector2(1, 0);
                        if (timer >= time)
                        {
                            EnemyShotClone = GameObject.Instantiate(EnemyShot,
                                new Vector3(EnemyTransform.position.x + 1f, EnemyTransform.position.y, EnemyTransform.position.z)
                                , Quaternion.identity, EnemyTransform);
                            EnemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
                            Destroy(EnemyShotClone, 2f);
                            timer = 0;
                        }
                    }
                    break;
                default:
                    break;
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
        OnDeath();
    }
}
