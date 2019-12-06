using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Controll : MonoBehaviour
{
    public float Speed;
    public KeyCode Forward,
        Backward;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Forward))
        {
            rb.AddForce(rb.transform.right * Speed * 100 * Time.deltaTime);
        }
        else if (Input.GetKey(Backward))
        {
            rb.AddForce(-rb.transform.right * Speed * 100 * Time.deltaTime);
        }
    }
}
