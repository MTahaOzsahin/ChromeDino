using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemWeapons : PickableItems
{
    [Header("Components")]
    [SerializeField] GameObject Weapon;   
   
    [SerializeField] GameObject WeaponShot;
    public GameObject WeaponShotClone;
    private GameObject PickedWeapon;
    
    

    public LayerMask DamageableLayerMask;

    



   
    public override bool IsMainCharacterNear()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(objectSpriteRenderer.bounds.center, 0.01f, MainCharacterLayerMask);

        if (collider2D)
        {           
            return true;
        }      
        return false;
    }


  
    private void PickupWeapon()
    {
        if (IsMainCharacterNear() && Input.GetKeyDown(KeyCode.E) && maincharacterGameObject.transform.rotation.y >= 0 )
        {
            if (maincharacterGameObject.transform.childCount != 0)
            {
                maincharacterGameObject.transform.DetachChildren();
                Destroy(PickedWeapon);
            }
            PickedWeapon = GameObject.Instantiate(Weapon, new Vector3(maincharacterGameObject.transform.position.x + 0.5f,
                maincharacterGameObject.transform.position.y + 0.25f, maincharacterGameObject.transform.position.z),
                Quaternion.Euler(0, 0, 45), maincharacterGameObject.transform);
                PickedWeapon.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            Destroy(gameObject);
        }
        else if (IsMainCharacterNear()  && Input.GetKeyDown(KeyCode.E) && maincharacterGameObject.transform.rotation.y <= 0)
        {
            if (maincharacterGameObject.transform.childCount != 0)
            {
                maincharacterGameObject.transform.DetachChildren();
                Destroy(PickedWeapon);
            }
            PickedWeapon = GameObject.Instantiate(Weapon, new Vector3(maincharacterGameObject.transform.position.x - 0.5f,
                maincharacterGameObject.transform.position.y + 0.25f, maincharacterGameObject.transform.position.z),
                Quaternion.Euler(0, -180, 45), maincharacterGameObject.transform);
            PickedWeapon.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            Destroy(gameObject);
        }
    }

   
   

   
    public void MagicShot()
    {
        Vector3 mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
        mouseposition = mouseposition - maincharacterGameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Weapon.transform.parent == false)
        {

            if (maincharacterGameObject.transform.rotation.y >= 0)
            {
                WeaponShotClone = GameObject.Instantiate(WeaponShot, new Vector3(Weapon.transform.position.x + 0.4f,
                Weapon.transform.position.y + 0.25f, Weapon.transform.position.z), Quaternion.identity);
                WeaponShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(mouseposition.x * 1.5f, mouseposition.y * 1.5f);

            }
            
            else
            {
                WeaponShotClone = GameObject.Instantiate(WeaponShot, new Vector3(Weapon.transform.position.x - 0.4f,
                Weapon.transform.position.y + 0.25f, Weapon.transform.position.z), Quaternion.Euler(0, -180, 0));
                WeaponShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(mouseposition.x * 1.5f, mouseposition.y * 1.5f);

            }


        }
        Destroy(WeaponShotClone, 1f);
    }
    
    private void FixedUpdate()
    {
       
    }
    private void Update()
    {        
        MagicShot();
        IsMainCharacterNear();
        PickupWeapon();       
    }
}
