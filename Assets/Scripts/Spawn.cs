using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }
    public void SpawnDroppedItem()
    {
        Vector2 playerpos = new Vector2(player.position.x - 1, player.position.y);
        Instantiate(item, playerpos, Quaternion.identity);
    }
}
