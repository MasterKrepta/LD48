using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMaker : MonoBehaviour
{
    Drillable drillable;
    PolygonCollider2D col;
    Rigidbody2D parentRb;
    // Start is called before the first frame update
    void Start()
    {
        
        drillable = FindObjectOfType<Drillable>();
        parentRb = GetComponentInParent<Rigidbody2D>();
        //col = GetComponent<PolygonCollider2D>();
        Invoke("MakeCave", .5f); // Small delay to let map spawn first

        Destroy(this.gameObject, 1);
    }

    private void MakeCave()
    {
        drillable.DrillHole(transform.position, GetComponent<BoxCollider2D>().edgeRadius);
        parentRb.gravityScale = 1;
        //foreach (var p in col.points)
        //{

        //    float radius = 1f;
        //    Vector3 loc = new Vector3(p.x, p.y);
        //    transform.parent = null;
        //    drillable.DrillHole(loc, radius);
        //}


    }
}
