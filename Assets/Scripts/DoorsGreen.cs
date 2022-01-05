using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsGreen : Doors
{
    public static int greenDoorint = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject && isGreenKeyHere)
        {
            Destroy(this.gameObject);
            greenDoorint = 1;
            
            
        }
    }
   
}
