using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Drillable : MonoBehaviour
{
    Tilemap map; 
    public Tilemap destoryedMap;
    public Tile drilledTile;

    private void Start()
    {
        map = GetComponent<Tilemap>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Explosion"))
        {
            Vector3 hitPos = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPos.x = hit.point.x - 0.01f * hit.normal.x;
                hitPos.y = hit.point.y - 0.01f * hit.normal.y;
                map.SetTile(map.WorldToCell(hitPos), null);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Explosion"))
        {
            
            DrillHole(collision.gameObject.transform.position, 1.5f);
        }
    }

    public void DrillHole(Vector3 drillLoc, float radius)
    {
        //todo DEBUG THIS if there is time

        for (int x = -(int)radius; x < radius; x++)
        {
            for (int y = -(int)radius; y < radius; y++)
            {
                Vector3Int tilePos = map.WorldToCell(drillLoc + new Vector3(x, y, 0));
                if (map.GetTile(tilePos) != null);
                {
                    DestroyTile(tilePos);
                }
            }
        }
    }

    private void DestroyTile(Vector3Int tilePos)
    {
        if (map.GetTile(tilePos) != null)
        {
            destoryedMap.SetTile(tilePos, drilledTile);
        }
        map.SetTile(tilePos, null);
        
        
    }

    
}
