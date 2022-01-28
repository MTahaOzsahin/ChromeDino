using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemsKey : PickableItems
{
    [SerializeField] GameObject keyPrefab;
    private GameObject clonedKeyPrefab;
    [SerializeField] GameObject mainCamera;
    public enum keyTypeSelect { Red, Purple, Green, Blue};
    public keyTypeSelect keyTypeSelection;

    private void OnEnable()
    {
        Doors.doorUnlocked += KeyDestroyer;
    }
    private void OnDisable()
    {
        Doors.doorUnlocked -= KeyDestroyer;
    }

    


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (keyTypeSelection)
        {
            case keyTypeSelect.Red:

                clonedKeyPrefab = GameObject.Instantiate(keyPrefab,
                  new Vector3(mainCamera.transform.position.x - 8f, mainCamera.transform.position.y + 4.5f, mainCamera.transform.position.z + 1f),
                  Quaternion.identity,mainCamera.transform);
                
                Destroy(this.gameObject);
                break;
            case keyTypeSelect.Purple:
                clonedKeyPrefab = GameObject.Instantiate(keyPrefab,
                  new Vector3(mainCamera.transform.position.x - 8f, mainCamera.transform.position.y + 4f, mainCamera.transform.position.z + 1f),
                  Quaternion.identity, mainCamera.transform);
               
                Destroy(this.gameObject);
                break;
            case keyTypeSelect.Green:
                clonedKeyPrefab = GameObject.Instantiate(keyPrefab,
                  new Vector3(mainCamera.transform.position.x - 8f, mainCamera.transform.position.y + 3.5f, mainCamera.transform.position.z + 1f),
                  Quaternion.identity, mainCamera.transform);
                
                Destroy(this.gameObject);
                break;
            case keyTypeSelect.Blue:
                clonedKeyPrefab = GameObject.Instantiate(keyPrefab,
                  new Vector3(mainCamera.transform.position.x - 8f, mainCamera.transform.position.y + 3f, mainCamera.transform.position.z + 1f),
                  Quaternion.identity, mainCamera.transform);
                
                Destroy(this.gameObject);
                break;
            default:
                break;
        }

        
    }

   

    void KeyDestroyer()
    {
        Debug.Log("Door i unlocked");
    }

    


}
