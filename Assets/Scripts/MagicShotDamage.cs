using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShotDamage : PickableItemWeapons  
{
    [SerializeField] SpriteRenderer WeaponShotCloneSp;
    [SerializeField] GameObject WeaponShotCloneObject;
    [SerializeField] LayerMask MainCharacterDamageLayer;
    public static int MagicShotTakenDamage = 10;



   

    

    public Health health;

    private void Awake()
    {
        WeaponShotCloneSp = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
    }

    
    
    public void Attack()
    {
        Collider2D[] hitResult = Physics2D.OverlapCircleAll(WeaponShotCloneSp.bounds.center, 0.6f, DamageableLayerMask | MainCharacterDamageLayer);
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
    
    

    private void FixedUpdate()
    {      
        Attack();
    }
    private void Update()
    {
        
    }
}
