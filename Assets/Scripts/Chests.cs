using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Health
{
    [SerializeField] Animator chesanimator;
    [SerializeField] GameObject shotforchest;

    public enum ChestType { red = 1,blue = 2,purple = 3,green = 4};
    public ChestType chestType;

     MagicShotDamage.ShotType magicshotdamage;
    
   
    
    private void Awake()
    {
        chesanimator = GetComponent<Animator>();
    }
    void Deneme()
    {
        if ((int)magicshotdamage == (int)chestType)
        {
            Debug.Log("Akýlsaððlýnýkaybet");
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
        Deneme();
        OnDeath();
    }
}
