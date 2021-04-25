using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private void Awake()
    {
        Game.NumTrapped++;
        GetComponentInChildren<HoleMaker>().enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        print("Miner has been resuced");
        Game.NumTrapped--;
        Game.NumRescued++;
    }
}
