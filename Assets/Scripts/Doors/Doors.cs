using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    ObjectTypeDetecter objectSelfType;

    public static event Action doorDestoyed;

    private void Awake()
    {
        objectSelfType = GetComponent<ObjectTypeDetecter>();
    }
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

    ObjectTypeDetecter objectType = collision.collider.GetComponentInChildren<ObjectTypeDetecter>();
        

        if (objectType != null)
        {
            switch (objectSelfType.objectType)
            {
                case ObjectTypeDetecter.ObjectType.red:
                    if (objectSelfType.objectType == objectType.objectType)
                    {                       
                        Destroy(this.gameObject);
                        collision.collider.gameObject.transform.GetChild(0).transform.parent = null;
                        doorDestoyed?.Invoke();
                    }
                    break;
                case ObjectTypeDetecter.ObjectType.blue:
                    if (objectSelfType.objectType == objectType.objectType)
                    {
                        Destroy(this.gameObject);
                        collision.collider.gameObject.transform.DetachChildren();
                    }
                    break;
                case ObjectTypeDetecter.ObjectType.purple:
                    if (objectSelfType.objectType == objectType.objectType)
                    {
                        Destroy(this.gameObject);
                        collision.collider.gameObject.transform.DetachChildren();
                    }
                    break;
                case ObjectTypeDetecter.ObjectType.green:
                    if (objectSelfType.objectType == objectType.objectType)
                    {
                        Destroy(this.gameObject);
                        collision.collider.gameObject.transform.DetachChildren();
                    }
                    break;
                default:
                    break;
            }
        }
    }
    
    
}
