using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShotDamage : PickableItemWeapons
{
    [SerializeField] SpriteRenderer WeaponShotCloneSp;
    public GameObject WeaponShotCloneObject;
    


    private void Awake()
    {
        WeaponShotCloneSp = GetComponent<SpriteRenderer>();      
    }

    
    public bool ShotDamage()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(WeaponShotCloneSp.bounds.center, 0.4f, DamageableLayerMask);
        if (collider2D)
        {
            Destroy(WeaponShotCloneObject);
            
            return true;
        }      
        return false;
    }

    

    private void FixedUpdate()
    {
        ShotDamage();     
    }
    private void Update()
    {
       
    }
}
