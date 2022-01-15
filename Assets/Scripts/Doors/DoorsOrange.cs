using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsOrange : Doors
{
    public static bool isdoorunlocked;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject && isOrangeKeyHere)
        {
            Destroy(this.gameObject);
            isdoorunlocked = true;
        }
    }
    
}
