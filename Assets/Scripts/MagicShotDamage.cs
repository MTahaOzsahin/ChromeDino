using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShotDamage : PickableItemWeapons  /*IDamageable<int>*/
{
    [SerializeField] SpriteRenderer WeaponShotCloneSp;
    [SerializeField] GameObject WeaponShotCloneObject;
    public int MagicShotTakenDamage;

    public  enum ShotType { red = 1, blue = 2, purple = 3, green = 4 };
    public  ShotType shotType;

    public Health health;

    private void Awake()
    {
        WeaponShotCloneSp = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
    }

    
    
    public void Attack()
    {
        Collider2D[] hitResult = Physics2D.OverlapCircleAll(WeaponShotCloneSp.bounds.center, 0.4f, DamageableLayerMask);
        if (hitResult == null)
            return;
        foreach (Collider2D hit in hitResult)
        {
            if (hit.GetComponent<Health>() != null)
            {
                hit.GetComponent<Health>().TakeDamage(MagicShotTakenDamage);
                Destroy(WeaponShotCloneObject);
            }
            
        }
    }
    
    private void OnDrawGizmosSelected()
    {   
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawCube(WeaponShotCloneSp.bounds.center, new Vector3(1.1f, 0.3f,0));
    }


    private void FixedUpdate()
    {      
        Attack();
    }
    private void Update()
    {
        
    }
}
