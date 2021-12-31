using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBlue : TeleportBase, ITeleportation
{
    
    

    private void Awake()
    {
        spriterendererteleport = GetComponent<SpriteRenderer>();
    }

    public void Teleport()
    {
        if (IsMainCharacterNear() && teleportdetection == 1)
        {
            maincharacter.transform.position = new Vector3(teleport2.transform.position.x + 1, teleport2.transform.position.y,
               maincharacter.transform.position.z);
        }
    }


    /*
    protected override bool IsMainCharacterNear()
    {
        //return base.IsMainCharacterNear();
    }

    private void FixedUpdate()
    {
       // Teleport();
        Debug.Log(teleportdetection);
    }





    /*
     * else if (IsTeleportNear1() && Input.GetKey(KeyCode.Space))
        {
            maincharacterrb2d.transform.position = new Vector3(teleport2.transform.position.x + 1, teleport2.transform.position.y,
               maincharacterrb2d.transform.position.z);
        }
        else if (IsTeleportNear2() && Input.GetKey(KeyCode.Space))
        {
            maincharacterrb2d.transform.position = new Vector3(teleport1.transform.position.x + 1, teleport1.transform.position.y,
               maincharacterrb2d.transform.position.z);
        }
        else if (IsTeleportNear3() && Input.GetKey(KeyCode.Space))
        {
            maincharacterrb2d.transform.position = new Vector3(teleport4.transform.position.x + 1, teleport4.transform.position.y,
               maincharacterrb2d.transform.position.z);
        }
        else if (IsTeleportNear4() && Input.GetKey(KeyCode.Space))
        {
            maincharacterrb2d.transform.position = new Vector3(teleport3.transform.position.x + 1, teleport3.transform.position.y,
               maincharacterrb2d.transform.position.z);
        }


     * 
     */
}
