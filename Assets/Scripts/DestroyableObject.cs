using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : Health , IHitEffect ,IDeathEffect
{
   public enum DestroyableObjectType
    {
        Tree,
        Barrel,

    }
    public DestroyableObjectType destroyableObjectType;

    Transform objectTransform;
    SpriteRenderer objectSpriteRenderer;

    private void Awake()
    {
        objectSpriteRenderer = GetComponent<SpriteRenderer>();
        objectTransform = GetComponent<Transform>();
    }

    public override void TakeDamage(int damage)
    {
      
            switch (destroyableObjectType)
            {
                case DestroyableObjectType.Tree:
                    base.TakeDamage(damage);
                    HitEffect();
                    break;
                case DestroyableObjectType.Barrel:
                    base.TakeDamage(damage);
                    HitEffect();
                    break;
                default:
                    break;
            }
        
        
        
    }
    public override bool CheckIfDead()
    {
        return base.CheckIfDead();
    }
    public override void OnDeath()
    {

        if (CheckIfDead())
        {
            
            Destroy(gameObject, 1.1f);
            DeathEffect();
            
        }
        
    }

    public void HitEffect() //Hit effect for generic object
    {
       
            objectTransform.DOPunchPosition(new Vector3(0.3f, 0, 0), 0.3f, 10, 0.5f);
            //objectTransform.DOShakePosition(0.3f, new Vector3(0.5f, 0.1f, 0), 10, 50);
            Tween colorTween = objectSpriteRenderer.DOBlendableColor(Color.red, 0.3f);
            colorTween.OnComplete(() => objectSpriteRenderer.DOBlendableColor(Color.white, 0.05f));
        
        

    }
    public void DeathEffect() // Death effect for generic object 
    {
        Tween rotateTween =  objectTransform.DORotate(new Vector3(0, 0, 90f), 1f, RotateMode.Fast);
        
        Tween scaleTween =  objectTransform.DOScale(0.8f, 1f);

        DOTween.KillAll(true,1f);
    }
}
