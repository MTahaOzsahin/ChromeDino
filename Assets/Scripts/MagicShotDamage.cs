using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShotDamage : PickableItemWeapons  /*IDamageable<int>*/
{
    [SerializeField] SpriteRenderer WeaponShotCloneSp;
    [SerializeField] GameObject WeaponShotCloneObject;
    public int MagicShotTakenDamage;

    public bool isAttacking = false;

    public Health health;

    private void Awake()
    {
        WeaponShotCloneSp = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
    }


    public  bool ShotDamage()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(WeaponShotCloneSp.bounds.center, 0.4f, DamageableLayerMask);
        if (collider2D)
        {
            Destroy(WeaponShotCloneObject);

            return true;
        }
        return false;
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
            }
            
        }
    }
    //public void TakeDamage(int damage)
    //{
    //    Collider2D[] hitResult = Physics2D.OverlapBoxAll(WeaponShotCloneSp.bounds.center, new Vector3(1.1f, 0.3f, 0), DamageableLayerMask);
    //    if (hitResult == null)
    //        return;

    //    foreach (Collider2D hit in hitResult)
    //    {
    //        if (hit.GetComponent<IDamageable<int>>() != null)
    //        {
    //            hit.GetComponent<IDamageable<int>>().TakeDamage(MagicShotTakenDamage);
    //            Destroy(WeaponShotCloneObject);
    //        }
    //    }
    //}
    private void OnDrawGizmosSelected()
    {   
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawCube(WeaponShotCloneSp.bounds.center, new Vector3(1.1f, 0.3f,0));
    }


    private void FixedUpdate()
    {
        ShotDamage();
        //TakeDamage(MagicShotTakenDamage);
        //ShotDamageeeeee();
    }
    private void Update()
    {
       
    }
}
