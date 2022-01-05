using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemsKey : PickableItems
{
    public GameObject keyprefab;
    public GameObject clonedkeyprefab;

    public int c;



    private void Awake()
    {
        
    }

    public void DestroyAndFollow()
    {
        c = DoorsGreen.greenDoorint;

        if (IsMainCharacterNear() && CompareTag("redKey"))
        {
            clonedkeyprefab = GameObject.Instantiate(keyprefab, new Vector3(maincharacter.transform.position.x - 1,
                maincharacter.transform.position.y - 0.5f, maincharacter.transform.position.z), Quaternion.identity,maincharacter.transform);

            

            Destroy(this.gameObject);
          
        }
        else if (IsMainCharacterNear() && CompareTag("greenKey"))
        {
            clonedkeyprefab = GameObject.Instantiate(keyprefab, new Vector3(maincharacter.transform.position.x - 1,
                maincharacter.transform.position.y, maincharacter.transform.position.z), Quaternion.identity,maincharacter.transform);

            

            Destroy(this.gameObject);
        }
        else if (IsMainCharacterNear() && CompareTag("orangeKey"))
        {
            clonedkeyprefab = GameObject.Instantiate(keyprefab, new Vector3(maincharacter.transform.position.x - 1,
                maincharacter.transform.position.y + 0.5f, maincharacter.transform.position.z), Quaternion.identity,maincharacter.transform);

            

            Destroy(this.gameObject);
        }
        
    }
    
    

    private void FixedUpdate()
    {
        DestroyAndFollow();     
    }





    /*
     * 
     * clonedkeyprefab.transform.position = new Vector3(maincharacter.transform.position.x - 1,
                maincharacter.transform.position.y,
              maincharacter.transform.position.z);
     * 
     * 
     * 
     * 
     */
}
