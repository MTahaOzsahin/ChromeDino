using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IOnDeath
{
    public int ObjectHealth;
    public bool IsShotHappend;
   

    

    public virtual void TakeDamage(int damage)
    {
       
        ObjectHealth -= damage;
    }
    public virtual bool CheckIfDead()
    {
       
        if (ObjectHealth <=0)
        {
            ObjectHealth = 0;
            return true;
        }
        return false;
    }
    public virtual void OnDeath()
    {
        if (CheckIfDead())
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        
    }
}
