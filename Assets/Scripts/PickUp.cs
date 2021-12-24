using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // Item can be added
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
