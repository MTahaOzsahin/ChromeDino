using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int objectHealth;
    
   

    

    public virtual void TakeDamage(int damage)
    {
       
        objectHealth -= damage;
    }
    public virtual bool CheckIfDead()
    {
       
        if (objectHealth <=0)
        {
            objectHealth = 0;
            return true;
        }
        return false;
    }
    public virtual void OnDeath()
    {
        if (CheckIfDead())
        {
            Destroy(gameObject,1.1f);
        }
    }
    private void FixedUpdate()
    {
        OnDeath();
    }
}
