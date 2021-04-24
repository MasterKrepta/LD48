using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 500, speed = 2f, throwForce = 200f;
    Vector3 movement;
    Rigidbody2D rb;
    [SerializeField] GameObject Bomb, throwPoint;
    public bool CanThrow = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = GetInput();
        transform.position += movement * Time.deltaTime * speed;
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.G) && CanThrow)
        {
            CanThrow = false; // This is for performance reasons
            ThrowBomb();
        }
        
    }

    private void ThrowBomb()
    {
        
        GameObject go = Instantiate(Bomb, throwPoint.transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().AddForce(throwPoint.transform.right * throwForce);
    }


    private Vector3 GetInput()
    {
        
        return new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }
}
