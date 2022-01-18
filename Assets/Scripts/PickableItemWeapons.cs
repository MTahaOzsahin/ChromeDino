using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemWeapons : PickableItems, IParticleSystem /*IMagicShot */
{
    [Header("Components")]
    [SerializeField] GameObject Weapon;   
    [SerializeField] ParticleSystem particleSystemeffect;
    [SerializeField] GameObject WeaponShot;
    public GameObject WeaponShotClone;
    private GameObject PickedWeapon;
    
    

    public LayerMask DamageableLayerMask;
   



    private void Awake()
    {
        particleSystemeffect = GetComponent<ParticleSystem>();
        
}
    public override bool IsMainCharacterNear()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(spriteRenderer.bounds.center, 0.01f, MainCharacterLayerMask);

        if (collider2D)
        {           
            return true;
        }      
        return false;
    }


  
    private void PickupWeapon()
    {
        if (IsMainCharacterNear() && Input.GetKeyDown(KeyCode.E) && maincharacter.transform.rotation.y >= 0 )
        {
            if (maincharacter.transform.childCount != 0)
            {
                maincharacter.transform.DetachChildren();
                Destroy(PickedWeapon);
            }
            PickedWeapon = GameObject.Instantiate(Weapon, new Vector3(maincharacter.transform.position.x + 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, 0, 45), maincharacter.transform);
                PickedWeapon.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            Destroy(gameObject);
        }
        else if (IsMainCharacterNear()  && Input.GetKeyDown(KeyCode.E) && maincharacter.transform.rotation.y <= 0)
        {
            if (maincharacter.transform.childCount != 0)
            {
                maincharacter.transform.DetachChildren();
                Destroy(PickedWeapon);
            }
            PickedWeapon = GameObject.Instantiate(Weapon, new Vector3(maincharacter.transform.position.x - 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, -180, 45), maincharacter.transform);
            PickedWeapon.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            Destroy(gameObject);
        }
    }

   
   

    public void ParticleSystemConfig()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !Weapon.transform.parent == false)
        {
            particleSystemeffect.Play();
        }
        
    }
    public void MagicShot()
    {
        Vector3 mouseposition = Input.mousePosition;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
        mouseposition = mouseposition - maincharacter.transform.position;
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Weapon.transform.parent == false)
        {

            if (maincharacter.transform.rotation.y >= 0)
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
