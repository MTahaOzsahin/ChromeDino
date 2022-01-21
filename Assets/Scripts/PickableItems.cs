using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItems : MonoBehaviour 
{
    public SpriteRenderer objectSpriteRenderer;
    public Collider2D objectCollider2D;

    public GameObject maincharacterGameObject;

    public Transform[] ChildList;
   

    public LayerMask MainCharacterLayerMask;


    

    private void Awake()
    {
        objectSpriteRenderer = GetComponent<SpriteRenderer>();
        objectCollider2D = GetComponent<Collider2D>();
        
    }

    public virtual bool IsMainCharacterNear()
    {

        Collider2D collider2D = Physics2D.OverlapCircle(objectSpriteRenderer.bounds.center, 0.5f, MainCharacterLayerMask);

        if (collider2D)
        {           
            return true;           
        }
        return false;
    }
    
}
