using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemWeapons : PickableItems, IParticleSystem, IMagicShot 
{
    [SerializeField] GameObject Weapon;   
    [SerializeField] ParticleSystem particleSystemeffect;
    [SerializeField] GameObject WeaponShot;
    private GameObject WeaponShotClone;
    private GameObject CloneWeapon;

    [SerializeField] GameObject[] WeaponsList; //will try to get a list that gameobjects use this script
    

    private void Awake()
    {
        particleSystemeffect = GetComponent<ParticleSystem>();
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (maincharacter.transform.rotation.y >= 0 && Input.GetKey(KeyCode.E))
        {
            CloneWeapon = GameObject.Instantiate(Weapon, new Vector3(maincharacter.transform.position.x + 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, 0, 45), maincharacter.transform);
            CloneWeapon.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            Destroy(this.gameObject);
        }
        else if (maincharacter.transform.rotation.y <= 0 && Input.GetKey(KeyCode.E))
        {
            CloneWeapon = GameObject.Instantiate(Weapon, new Vector3(maincharacter.transform.position.x - 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, -180, 45), maincharacter.transform);
            CloneWeapon.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            Destroy(this.gameObject);
        }

    }
    




    public void ParticleSystemConfig()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !Weapon.transform.parent == false)
        {
            particleSystemeffect.Play();
        }
        
    }
    public  void MagicShot() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Weapon.transform.parent == false)
        {
            
            if (maincharacter.transform.rotation.y >= 0)
            {
                WeaponShotClone = GameObject.Instantiate(WeaponShot, new Vector3(Weapon.transform.position.x + 0.4f,
                Weapon.transform.position.y + 0.25f, Weapon.transform.position.z), Quaternion.identity);
                WeaponShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
            }
             else 
            {
                WeaponShotClone = GameObject.Instantiate(WeaponShot, new Vector3(Weapon.transform.position.x - 0.4f,
                Weapon.transform.position.y + 0.25f, Weapon.transform.position.z), Quaternion.Euler(0,-180,0));
                WeaponShotClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            }

           
        }
        Destroy(WeaponShotClone, 1f);
    }
    
    private void FixedUpdate()
    {
        
    }
    private void Update()
    {
       // ParticleSystemConfig();
        MagicShot();
    }
}
