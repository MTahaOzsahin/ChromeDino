using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRed : TeleportBase, ITeleportation
{
    private void Awake()
    {
        spriterendererteleport = GetComponent<SpriteRenderer>();
    }
    public static int teleportdetection;
    public void Teleport()
    {

        teleportdetection = Character.teleportdetection;
        if (teleportdetection == 5 && Input.GetKeyDown(KeyCode.Space))
        {
            maincharacter.transform.position = new Vector3(teleport2.transform.position.x + 2, teleport2.transform.position.y,
                maincharacter.transform.position.z);
        }

        else if (teleportdetection == 7 && Input.GetKeyDown(KeyCode.Space))
        {
            maincharacter.transform.position = new Vector3(teleport1.transform.position.x + 2, teleport1.transform.position.y,
               maincharacter.transform.position.z);
        }
        else if (teleportdetection == 9 && Input.GetKeyDown(KeyCode.Space))
        {
            maincharacter.transform.position = new Vector3(teleport4.transform.position.x + 1, teleport4.transform.position.y,
               maincharacter.transform.position.z);
        }
        else if (teleportdetection == 11 && Input.GetKeyDown(KeyCode.Space))
        {
            maincharacter.transform.position = new Vector3(teleport3.transform.position.x + 1, teleport3.transform.position.y,
               maincharacter.transform.position.z);
        }

    }
}
