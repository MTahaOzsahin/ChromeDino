using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItems : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Collider2D itemcollider2d;

    public GameObject maincharacter;
   

    public LayerMask MainCharacterLayerMask;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemcollider2d = GetComponent<Collider2D>();       
    }

    public virtual bool IsMainCharacterNear()
    {

        Collider2D collider2D = Physics2D.OverlapCircle(spriteRenderer.bounds.center, 0.5f, MainCharacterLayerMask);

        if (collider2D == true)
        {           
            return true;           
        }
        return false;
    }
    

}
