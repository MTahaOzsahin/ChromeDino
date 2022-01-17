using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Health 
{
    [SerializeField] Animator chesanimator;
    [SerializeField] GameObject shotforchest;

    //public enum ObjectType { red = 1, blue = 2, purple = 3, green = 4 };
    //public ObjectType chestType;

    //MagicShotDamage.ObjectType MagicshotType;


    ObjectTypeDetecter objectSelfType; 



    private void Awake()
    {
        chesanimator = GetComponent<Animator>();
        objectSelfType = GetComponent<ObjectTypeDetecter>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ObjectTypeDetecter objectType = collision.collider.GetComponent<ObjectTypeDetecter>();
        if (objectType != null)
        {
            switch (objectType.objectType)
            {
                case ObjectTypeDetecter.ObjectType.red:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.red)
                    {
                        Debug.Log("you hit red ches with red shot");
                    }
                    
                    break;
                case ObjectTypeDetecter.ObjectType.blue:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.blue)
                    {
                        Debug.Log("you hit blue ches with blue shot");
                    }
                    
                    break;
                case ObjectTypeDetecter.ObjectType.purple:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.purple)
                    {
                        Debug.Log("you hit purple ches with purple shot");
                    }
             
                    break;
                case ObjectTypeDetecter.ObjectType.green:
                    if (objectSelfType.objectType == ObjectTypeDetecter.ObjectType.green)
                    {
                        Debug.Log("you hit green ches with green shot");
                    }
                   
                    break;
                default:
                    break;
            }
        }
    }

    //void Deneme()
    //{
    //    Debug.Log((int)shotType);
    //    Debug.Log((int)chestType);


    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{     
    //    MagicShotDamage magicShotDamage = collision.gameObject.GetComponent<MagicShotDamage>();
    //    if (magicShotDamage.shotType == MagicShotDamage.ObjectType.red)
    //    {
    //        Debug.Log("a");
    //    }
    //    Debug.Log(collision.gameObject.GetComponent<MagicShotDamage.ObjectType>());
    //    Debug.Log(collision.gameObject.GetComponent<MagicShotDamage>().shotType);

    //}

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
        //if (chestType == ChestType.red)
        //{
        //    Debug.Log("red");
        //}
        //if (chestType == ChestType.blue)
        //{
        //    Debug.Log("blue");
        //}
        //else
        //{
        //    Debug.Log("kalan");
        //}
        //Deneme();
        OnDeath();
        
    }

    
}
