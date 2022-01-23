using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    ObjectTypeDetecter objectSelfType;
    [SerializeField] GameObject mainCamera;
    
    public static event Action doorUnlocked;
   

    private void Awake()
    {
        objectSelfType = GetComponent<ObjectTypeDetecter>();
    }
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        ObjectTypeDetecter objectType = mainCamera.GetComponentInChildren<ObjectTypeDetecter>();

        

        if (objectType != null)
        {
            switch (objectSelfType.objectType)
            {
                case ObjectTypeDetecter.ObjectType.red:
                    if (objectSelfType.objectType == objectType.objectType)
                    {
                        Destroy(this.gameObject);
                        mainCamera.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    break;
                case ObjectTypeDetecter.ObjectType.purple:
                    if (objectSelfType.objectType == objectType.objectType)
                    {
                        Destroy(this.gameObject);
                        mainCamera.transform.GetChild(1).gameObject.SetActive(false);

                    }
                    break;
                case ObjectTypeDetecter.ObjectType.green:
                    if (objectSelfType.objectType == objectType.objectType)
                    {
                        Destroy(this.gameObject);
                        mainCamera.transform.GetChild(2).gameObject.SetActive(false);

                    }
                    break;
                case ObjectTypeDetecter.ObjectType.blue:
                    if (objectSelfType.objectType == objectType.objectType)
                    {
                        Destroy(this.gameObject);
                        mainCamera.transform.GetChild(3).gameObject.SetActive(false);

                    }
                    break;
                
                
                default:
                    break;
            }
            doorUnlocked?.Invoke();
        }
    }
    
    
}
