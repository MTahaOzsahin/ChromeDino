using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsGreen : Doors
{
    public static bool isdoorunlocked;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isdoorunlocked = false;
        if (collision.gameObject && isGreenKeyHere)
        {
            Destroy(this.gameObject);
            isdoorunlocked = true;
        }
    }
   
}
