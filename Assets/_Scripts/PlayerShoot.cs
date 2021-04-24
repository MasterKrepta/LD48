using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject Bomb, throwPoint, weapon;
    float throwForce = 200f;
    public bool CanThrow = true;
    GroundScript gs;
    // Update is called once per frame

    private void Start()
    {
        gs = FindObjectOfType<GroundScript>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && CanThrow)
        {
            gs.StopReset(); //TODO HORRIBLE

            CanThrow = false; // This is for performance reasons
            //StartCoroutine("ResetCanThrow");
            ThrowBomb();
        }
    }


        
    

    void Aim()
{
    var offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    offset.Normalize();

    float rot_z = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
    weapon.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
}

private void ThrowBomb()
{

    GameObject go = Instantiate(Bomb, throwPoint.transform.position, Quaternion.identity);
    go.GetComponent<Rigidbody2D>().AddForce(throwPoint.transform.right * throwForce);
    //Destroy(go, drillTime);
}

}
