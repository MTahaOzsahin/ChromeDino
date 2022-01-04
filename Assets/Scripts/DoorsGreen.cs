using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsGreen : Doors
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject && isGreenKeyHere)
        {
            Destroy(this.gameObject);
            Destroy(MainCharacter.transform.GetChild(0));
            
        }
    }
   
}
