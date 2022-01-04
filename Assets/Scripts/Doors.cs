using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Collider2D doorcollider2d;
    public GameObject MainCharacter;
    

    public bool isGreenKeyHere = false;
    public bool isRedKeyHere = false;
    public bool isOrangeKeyHere = false;

    private void Awake()
    {
        doorcollider2d = GetComponent<Collider2D>();       
    }
   
    void KeyCheck()
    {
        if (MainCharacter.transform.Find("keyGreen(Clone)"))
        {
            isGreenKeyHere = true;            
        }
        if (!MainCharacter.transform.Find("keyGreen(Clone)"))
        {
            isGreenKeyHere = false;
        }
        if (MainCharacter.transform.Find("keyOrange(Clone)"))
        {
            isOrangeKeyHere = true;            
        }
        if (!MainCharacter.transform.Find("keyOrange(Clone)"))
        {
            isOrangeKeyHere = false;
        }
        if (MainCharacter.transform.Find("keyRed(Clone)"))
        {
            isRedKeyHere = true;           
        }
        if (!MainCharacter.transform.Find("keyRed(Clone)"))
        {
            isRedKeyHere = false;
        }
    }
    private void FixedUpdate()
    {
        KeyCheck();
    }
}
