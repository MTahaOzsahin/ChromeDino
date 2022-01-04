using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsRed : Doors
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject && isRedKeyHere)
        {
            Destroy(this.gameObject);
        }
    }
    
}
