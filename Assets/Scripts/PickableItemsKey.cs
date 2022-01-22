using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItemsKey : PickableItems
{
    [SerializeField] GameObject keyPrefab;
    public GameObject clonedkeyPrefab;
    public enum keyTypeSelect { Red, Purple, Green, Blue};
    public keyTypeSelect keyTypeSelection;

    private void OnEnable()
    {
        Doors.doorDestoyed += IsDoorDestoyedChecker;
    }
    private void OnDisable()
    {
        Doors.doorDestoyed -= IsDoorDestoyedChecker;
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        int a = 1;
        if (maincharacterGameObject.transform.rotation.y == 0)
        {
            a = -1;
        }
        switch (keyTypeSelection)
        {
            case keyTypeSelect.Red:
                clonedkeyPrefab = GameObject.Instantiate(keyPrefab,
                    new Vector3(maincharacterGameObject.transform.position.x + a, maincharacterGameObject.transform.position.y - 0.5f,
                    maincharacterGameObject.transform.position.z),
                Quaternion.identity, maincharacterGameObject.transform);
                clonedkeyPrefab.transform.SetSiblingIndex(0);
                clonedkeyPrefab.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                Destroy(this.gameObject);
                break;
            case keyTypeSelect.Purple:
                clonedkeyPrefab = GameObject.Instantiate(keyPrefab,
                    new Vector3(maincharacterGameObject.transform.position.x + a, maincharacterGameObject.transform.position.y,
                    maincharacterGameObject.transform.position.z),
                Quaternion.identity, maincharacterGameObject.transform);
                clonedkeyPrefab.transform.SetSiblingIndex(1);
                clonedkeyPrefab.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                Destroy(this.gameObject);
                break;
            case keyTypeSelect.Green:
                clonedkeyPrefab = GameObject.Instantiate(keyPrefab,
                    new Vector3(maincharacterGameObject.transform.position.x + a, maincharacterGameObject.transform.position.y + 0.5f,
                    maincharacterGameObject.transform.position.z),
                Quaternion.identity, maincharacterGameObject.transform);
                clonedkeyPrefab.transform.SetSiblingIndex(2);
                clonedkeyPrefab.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                Destroy(this.gameObject);
                break;
            case keyTypeSelect.Blue:
                clonedkeyPrefab = GameObject.Instantiate(keyPrefab,
                    new Vector3(maincharacterGameObject.transform.position.x + a, maincharacterGameObject.transform.position.y + 1f,
                    maincharacterGameObject.transform.position.z),
                Quaternion.identity, maincharacterGameObject.transform);
                clonedkeyPrefab.transform.SetSiblingIndex(3);
                clonedkeyPrefab.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                Destroy(this.gameObject);
                break;
            default:
                break;
        }

        
    }

   

    void IsDoorDestoyedChecker()
    {
        Debug.Log("eben");
        Destroy(gameObject.transform.Find("keyRed(Clone)"));
    }




}
