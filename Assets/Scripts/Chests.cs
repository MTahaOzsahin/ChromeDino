using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chests : Health , IHitEffect
{
    [SerializeField] Animator chesanimator;
    Transform chestTransform;
    SpriteRenderer chestSpriteRenderer;
   
    public static int DamagefromMagicShot;

    
    ObjectTypeDetecter objectSelfType; 



    private void Awake()
    {
        chesanimator = GetComponent<Animator>();
        objectSelfType = GetComponent<ObjectTypeDetecter>();
        chestTransform = GetComponent<Transform>();
        chestSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamagefromMagicShot = MagicShotDamage.MagicShotTakenDamage;
        ObjectTypeDetecter objectType = collision.collider.GetComponent<ObjectTypeDetecter>();
        if (objectType != null)
        {
            switch (objectType.objectType)
            {
                case ObjectTypeDetecter.ObjectType.red:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.red)
                    {
                        ObjectHealth -= DamagefromMagicShot;                       
                        Destroy(collision.gameObject);
                        HitEffect();
                    }
                    
                    break;
                case ObjectTypeDetecter.ObjectType.blue:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.blue)
                    {
                        ObjectHealth -= DamagefromMagicShot;
                        Destroy(collision.gameObject);
                        HitEffect();
                    }
                    
                    break;
                case ObjectTypeDetecter.ObjectType.purple:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.purple)
                    {
                        ObjectHealth -= DamagefromMagicShot;
                        Destroy(collision.gameObject);
                        HitEffect();
                    }
             
                    break;
                case ObjectTypeDetecter.ObjectType.green:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.green)
                    {
                        ObjectHealth -= DamagefromMagicShot;
                        Destroy(collision.gameObject);
                        HitEffect();
                    }
                   
                    break;
                default:
                    break;
            }
        }
    }


    public void HitEffect() //Hit effect for chests
    {
       // chestTransform.DOPunchPosition(new Vector3(0.5f, 0, 0), 0.3f, 10, 0.5f);
        chestTransform.DOShakePosition(0.3f, new Vector3(0.5f,0.1f,0), 10, 50);
        Tween colorTween = chestSpriteRenderer.DOBlendableColor(Color.red, 0.2f);
        colorTween.OnComplete(() => chestSpriteRenderer.DOBlendableColor(Color.white, 0.05f));

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
            OpenAndDestroyChes();
            Destroy(this.gameObject, 1f);

        }
    }
    private void OpenAndDestroyChes()
    {
        chesanimator.SetTrigger("IsDestroyed");
       
    }
    private void FixedUpdate()
    {
       
        OnDeath();
        
    }

    
}
