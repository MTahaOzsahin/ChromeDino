using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    
    public Collider2D doorscollider;
    public Inventory inventory;
    public GameObject Item;

    private void Awake()
    {
        doorscollider = GetComponent<Collider2D>();
        inventory = GameObject.FindGameObjectWithTag("player").GetComponent<Inventory>();
    }
    
}
