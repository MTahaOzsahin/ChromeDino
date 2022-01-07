using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemWeapons : PickableItems, IParticleSystem
{
    [SerializeField] GameObject Weapon;
    [SerializeField] GameObject CloneWeapon;
    [SerializeField] ParticleSystem particleSystemeffect;

    private void Awake()
    {
        particleSystemeffect = GetComponent<ParticleSystem>();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CloneWeapon = GameObject.Instantiate(Weapon, new Vector3(maincharacter.transform.position.x + 0.5f,
                maincharacter.transform.position.y + 0.25f, maincharacter.transform.position.z),
                Quaternion.Euler(0, 0, 45), maincharacter.transform);
        CloneWeapon.transform.localScale = new Vector3(0.6f, 0.6f, 1f);

        
        Destroy(this.gameObject);
    }

    public void ParticleSystemConfig()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            particleSystemeffect.Play();
        }
        
    }
    private void FixedUpdate()
    {
        
    }
    private void Update()
    {
        ParticleSystemConfig();
    }
}
