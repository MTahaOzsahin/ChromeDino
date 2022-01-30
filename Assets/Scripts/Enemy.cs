using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health , IHitEffect ,IDeathEffect
{
    [SerializeField] Animator enemyAnimator;
    [SerializeField] GameObject enemyGameObject;
    [SerializeField] Rigidbody2D enemyRigiBody2D;
    [SerializeField] SpriteRenderer enemySpriteRenderer;
    [SerializeField] Transform enemyTransform;
    [SerializeField] LayerMask mainCharacterLayerMask;

    [SerializeField] GameObject mainCharacterGameObject;
    [SerializeField] GameObject enemyShot;
    private GameObject enemyShotClone;

    float time = 4f;
    float timer;

    public enum EnemyType { yellow, grey, greyar,greenar};
    public EnemyType enemytype;    
 
    [SerializeField] enum EnemyMovementState { idle,walking};
    private EnemyMovementState enemymovementstate;
   
    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();      
        enemyRigiBody2D = GetComponent<Rigidbody2D>();
        enemyTransform = GetComponent<Transform>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        timer = Time.deltaTime;
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
            Destroy(gameObject,1.1f);
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
        enemyAnimator.SetBool("IsWalking", false);
    }
    void PlayWalkingAnim()
    {
        enemyAnimator.SetBool("IsWalking", true);
    }
    void SetMovementState (EnemyMovementState enemyMovementState)
    {
        enemymovementstate = enemyMovementState;
    }
    void SetEnemyState()
    {
       if (enemyRigiBody2D.velocity.x < 1 && enemyRigiBody2D.velocity.x > -1)
        {
            SetMovementState(EnemyMovementState.idle);
        }
        else
        {
            SetMovementState(EnemyMovementState.walking);
        }
        
    }
    void LeftAttack()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            enemyShotClone = GameObject.Instantiate(enemyShot,
                new Vector3(enemyTransform.position.x - 1f, enemyTransform.position.y, enemyTransform.position.z)
                , Quaternion.identity, enemyTransform);
            enemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
            Destroy(enemyShotClone, 2f);
            timer = 0;
        }
    }
    void RightAttack()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            enemyShotClone = GameObject.Instantiate(enemyShot,
                new Vector3(enemyTransform.position.x + 1f, enemyTransform.position.y, enemyTransform.position.z)
                , Quaternion.identity, enemyTransform);
            enemyShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            Destroy(enemyShotClone, 2f);
            timer = 0;
        }
    }
   

    void EnemyManager()
    {
        timer += Time.deltaTime;
        Collider2D collider2D = Physics2D.OverlapBox(enemySpriteRenderer.bounds.center,new Vector2 (15f,1f), 0f, mainCharacterLayerMask);
        if (collider2D == null)
        {
            return;
        }
           
        else
        {
            switch (enemytype)
            {
                case EnemyType.yellow:
                    if (enemyGameObject.transform.position.x > mainCharacterGameObject.transform.position.x)
                    {
                        LeftAttack();
                    }
                    else
                    {                      
                        RightAttack();                        
                    }
                    

                    break;
                case EnemyType.grey:
                    if (enemyGameObject.transform.position.x > mainCharacterGameObject.transform.position.x)
                    {
                        LeftAttack();
                    }
                    else
                    {
                        RightAttack();
                    }
                    break;
                case EnemyType.greyar:
                    if (enemyGameObject.transform.position.x > mainCharacterGameObject.transform.position.x)
                    {
                        enemyGameObject.transform.eulerAngles = new Vector2(0, 180);
                        enemyRigiBody2D.velocity = new Vector2(-1, 0);
                        LeftAttack();


                    }
                    else
                    {
                        enemyGameObject.transform.eulerAngles = new Vector2(0, 0);
                        enemyRigiBody2D.velocity = new Vector2(1, 0);
                        RightAttack();
                    }
                    break;
                case EnemyType.greenar:
                    if (enemyGameObject.transform.position.x > mainCharacterGameObject.transform.position.x)
                    {
                        enemyGameObject.transform.eulerAngles = new Vector2(0, 180);
                        enemyRigiBody2D.velocity = new Vector2(-1, 0);
                        LeftAttack();
                    }
                    else
                    {
                        enemyGameObject.transform.eulerAngles = new Vector2(0, 0);
                        enemyRigiBody2D.velocity = new Vector2(1, 0);
                        RightAttack();
                    }
                    break;
                default:
                    break;
            }
            
        }
        
    }
    


    private void Update()
    {       
        SetEnemyState();        
    }
    private void FixedUpdate()
    {
        EnemyManager();
        PlayAnimationBasedOnState();
        OnDeath();
    }

    public void HitEffect()
    {
        enemyTransform.DOShakePosition(0.3f, new Vector3(0.3f, 0.1f, 0), 10, 50);
        Tween colorTween = enemySpriteRenderer.DOBlendableColor(Color.red, 0.2f);
        colorTween.OnComplete(() => enemySpriteRenderer.DOBlendableColor(Color.white, 0.05f));
    }

    public void DeathEffect()
    {
        Tween rotateTween = enemyTransform.DORotate(new Vector3(0, 0, 90f), 1f, RotateMode.Fast);

        Tween scaleTween = enemyTransform.DOScale(0.8f, 1f);

        DOTween.KillAll(true, 1f);
    }
}
