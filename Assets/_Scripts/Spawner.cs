using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] Miners;

    [SerializeField] List<GameObject> SpawnPoints;

    

    // Start is called before the first frame update
    void Start()
    {
        foreach (var miner in Miners)
        {
            int rand = Random.Range(0, SpawnPoints.Count);
            miner.transform.position = SpawnPoints[rand].transform.position;
            RemovePoint(SpawnPoints[rand]);
            miner.GetComponentInChildren<HoleMaker>().enabled = true;
        }    
    }

    

    void RemovePoint(GameObject pointToMove)
    {
        SpawnPoints.Remove(pointToMove);
    }
}
