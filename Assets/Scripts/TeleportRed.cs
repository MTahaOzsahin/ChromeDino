using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRed : TeleportBase
{
    private void Awake()
    {
        spriterendererteleport = GetComponent<SpriteRenderer>();
    }
   
}
