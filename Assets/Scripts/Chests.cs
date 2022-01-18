using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Health 
{
    [SerializeField] Animator chesanimator;
    [SerializeField] GameObject shotforchest;
    public static int DamagefromMagicShot;

    
    ObjectTypeDetecter objectSelfType; 



    private void Awake()
    {
        chesanimator = GetComponent<Animator>();
        objectSelfType = GetComponent<ObjectTypeDetecter>();
        
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
                    }
                    
                    break;
                case ObjectTypeDetecter.ObjectType.blue:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.blue)
                    {
                        ObjectHealth -= DamagefromMagicShot;
                        Destroy(collision.gameObject);
                    }
                    
                    break;
                case ObjectTypeDetecter.ObjectType.purple:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.purple)
                    {
                        ObjectHealth -= DamagefromMagicShot;
                        Destroy(collision.gameObject);
                    }
             
                    break;
                case ObjectTypeDetecter.ObjectType.green:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.green)
                    {
                        ObjectHealth -= DamagefromMagicShot;
                        Destroy(collision.gameObject);
                    }
                   
                    break;
                default:
                    break;
            }
        }
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
