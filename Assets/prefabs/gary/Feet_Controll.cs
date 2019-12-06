using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet_Controll : MonoBehaviour
{
    public float speed;

    public KeyCode Forward;
    public KeyCode Backward;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey(Forward))
        {
            rb.AddForce(rb.transform.right * speed * Time.deltaTime * 10000);
        }
        else if (Input.GetKey(Backward))
        {
            rb.AddForce(-rb.transform.right * speed * Time.deltaTime * 10000);
        }

    }
}
