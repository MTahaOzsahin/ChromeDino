using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Health
{
    [SerializeField] Animator chesanimator;
    [SerializeField] GameObject shotforchest;
    
    private void Awake()
    {
        chesanimator = GetComponent<Animator>();
    }
    public override void TakeDamage(int damage)
    {
        
        if (shotforchest)
        {
           base.TakeDamage(damage);
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
            OpenAndDestroyChes();
            Destroy(this.gameObject, 1f);

        }
    }
    private void OpenAndDestroyChes()
    {
        chesanimator.SetTrigger("IsDestroyed");
       
    }
}
