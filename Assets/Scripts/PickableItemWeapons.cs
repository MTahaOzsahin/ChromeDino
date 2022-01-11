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

    public enum SelectedWeapons { Empty, Weapon1, Weapon2, Weapon3, Weapon4};

    public SelectedWeapons CharacterSelectedWeapon;

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

    public void SetCharacterWeaponBasedOnState()
    {
        switch (CharacterSelectedWeapon)
        {
            case SelectedWeapons.Empty:
                SetCharacterWeaponEmpty();
                break;
            case SelectedWeapons.Weapon1:
                SetCharacterWeapon1();
                break;
            case SelectedWeapons.Weapon2:
                SetCharacterWeapon2();
                break;
            case SelectedWeapons.Weapon3:
                SetCharacterWeapon3();
                break;
            case SelectedWeapons.Weapon4:
                SetCharacterWeapon4();
                break;
            default:
                break;
        }

    }
    public void SetCharacterWeapon1()
    {

            swichedWeapon[0] = GameObject.Instantiate(Weapons[0], new Vector3(maincharacter.transform.position.x + 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, 0, 45), maincharacter.transform);
            swichedWeapon[0].transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        
    }
    public void SetCharacterWeapon2()
    {
      
            swichedWeapon[1] = GameObject.Instantiate(Weapons[1], new Vector3(maincharacter.transform.position.x + 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, 0, 45), maincharacter.transform);
            swichedWeapon[1].transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        
    }
    public void SetCharacterWeapon3()
    {
        
            swichedWeapon[2] = GameObject.Instantiate(Weapons[2], new Vector3(maincharacter.transform.position.x + 0.5f,
                 maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                 Quaternion.Euler(0, 0, 45), maincharacter.transform);
            swichedWeapon[2].transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        
    }
    public void SetCharacterWeapon4()
    {
        
            swichedWeapon[3] = GameObject.Instantiate(Weapons[3], new Vector3(maincharacter.transform.position.x + 0.5f,
                 maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                 Quaternion.Euler(0, 0, 45), maincharacter.transform);
            swichedWeapon[3].transform.localScale = new Vector3(0.6f, 0.6f, 1f);
        
    }
    public void SetCharacterWeaponEmpty()
    {
     
    }
    public void SetCharacterWeaponUse(SelectedWeapons selectedWeapons) 
    {
        CharacterSelectedWeapon = selectedWeapons;
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
        SetCharacterWeaponBasedOnState();
    }
}
