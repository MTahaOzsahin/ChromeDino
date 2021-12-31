using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBase : MonoBehaviour
{
    // This will be base class for teleportation. 
    // Then will add another child class blur teleport and red teleport.
    // Blue telpeorts will be two way portal yet, red ones only one way portal.
    // We will need self transfrom positions, collider and maincharacter positions.
    // Base class will take them from "character" script. I hope

    public  SpriteRenderer spriterendererteleport;

    public LayerMask MainCharacterLayerMask;

    public GameObject teleport1;
    public GameObject teleport2;
    public GameObject teleport3;
    public GameObject teleport4;

    public GameObject maincharacter;

    public int teleportdetection = 0;

    

    private void Awake()
    {
        spriterendererteleport = GetComponent<SpriteRenderer>();
    }

    protected virtual bool IsMainCharacterNear()
    {
        Collider2D collider = Physics2D.OverlapCircle(spriterendererteleport.bounds.center, 0.25f, MainCharacterLayerMask);
        if (collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }  
}
