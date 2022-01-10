using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemWeapons : PickableItems, IParticleSystem, IMagicShot 
{
    [SerializeField] GameObject Weapon;   
    [SerializeField] ParticleSystem particleSystemeffect;
    [SerializeField] GameObject WeaponShot;
    private GameObject WeaponShotClone;
    private GameObject PickedWeapon;
    private GameObject[] swichedWeapon = new GameObject[4];

    [SerializeField] GameObject[] Weapons;


    private void Awake()
    {
        particleSystemeffect = GetComponent<ParticleSystem>();
        
    }
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (maincharacter.transform.rotation.y >= 0 && Input.GetKey(KeyCode.E))
        {
            PickedWeapon = GameObject.Instantiate(Weapon, new Vector3(maincharacter.transform.position.x + 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, 0, 45), maincharacter.transform);
            PickedWeapon.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            Destroy(this.gameObject);
            
        }
        else if (maincharacter.transform.rotation.y <= 0 && Input.GetKey(KeyCode.E))
        {
            PickedWeapon = GameObject.Instantiate(Weapon, new Vector3(maincharacter.transform.position.x - 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, -180, 45), maincharacter.transform);
            PickedWeapon.transform.localScale = new Vector3(0.6f, 0.6f, 1f);
            Destroy(this.gameObject);
        }

    }

    public void SetCharacterWeapon()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            swichedWeapon[0] = GameObject.Instantiate(Weapons[0], new Vector3(maincharacter.transform.position.x + 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, 0, 45), maincharacter.transform);
            swichedWeapon[0].transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            swichedWeapon[1] = GameObject.Instantiate(Weapons[1], new Vector3(maincharacter.transform.position.x + 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, 0, 45), maincharacter.transform);
            swichedWeapon[1].transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            swichedWeapon[2] = GameObject.Instantiate(Weapons[2], new Vector3(maincharacter.transform.position.x + 0.5f,
                 maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                 Quaternion.Euler(0, 0, 45), maincharacter.transform);
            swichedWeapon[2].transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            swichedWeapon[3] = GameObject.Instantiate(Weapons[3], new Vector3(maincharacter.transform.position.x + 0.5f,
                 maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                 Quaternion.Euler(0, 0, 45), maincharacter.transform);
            swichedWeapon[3].transform.localScale = new Vector3(0.6f, 0.6f, 1f);
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
        SetCharacterWeapon();

    }
}
