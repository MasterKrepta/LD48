using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 500, speed = 2f, throwForce = 200f, drillTime = 0.3f, rechargeTime = 2f;
    [SerializeField] float Charges = 3, remainingCharges;
    Vector3 movement;
    Rigidbody2D rb;
    [SerializeField] GameObject Bomb, throwPoint, weapon;
    public bool CanThrow = true;
    GroundScript gs;
    [SerializeField] Image imsDrillCharges;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gs = FindObjectOfType<GroundScript>();
        remainingCharges = Charges;
    }

    // Update is called once per frame
    void Update()
    {
        movement = GetInput();
        Aim();

        transform.position += movement * Time.deltaTime * speed;
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(transform.up * jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.G) && CanThrow)
        {
            //gs.StopReset(); //TODO HORRIBLE
            UseCharge();
            
            
            //StartCoroutine("ResetCanThrow");
            ThrowBomb();
        }

    }

    private void LateUpdate()
    {
        
        imsDrillCharges.fillAmount += Time.deltaTime;
        Mathf.Clamp(imsDrillCharges.fillAmount, .1f, 1);
        
        
    }
    private void UseCharge()
    {
        remainingCharges--;
        imsDrillCharges.fillAmount = (remainingCharges / Charges);
        if (remainingCharges <= 0)
        {
            StartCoroutine(RechargeDrill());
            CanThrow = false;
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

        GameObject go = Instantiate(Bomb, throwPoint.transform.position, throwPoint.transform.rotation);
        go.GetComponent<Rigidbody2D>().AddForce(throwPoint.transform.right * throwForce);
        //Destroy(go, drillTime);
    }


    private Vector3 GetInput()
    {
        
        return new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }

    IEnumerator RechargeDrill()
    {
        yield return new WaitForSeconds(rechargeTime);
        remainingCharges = Charges;
        CanThrow = true;
    }



}
