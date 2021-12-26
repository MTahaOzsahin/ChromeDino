using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType {MANA, HEALTH,KEYS };

public class Item : MonoBehaviour
{
    public ItemType type;

    public Sprite spriteNeutral;

    public Sprite spriteHighlighted;

    public int maxSize;


    public void Use()
    {
        switch (type)
        {
            case ItemType.MANA:
                Debug.Log("used mana");
                break;
            case ItemType.HEALTH:
                Debug.Log("used health");
                break;
            case ItemType.KEYS:
                Debug.Log("picked keys");
                break;
            
        }
    }
}
