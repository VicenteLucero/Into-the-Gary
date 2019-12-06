using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elbow_Controll : MonoBehaviour
{
    public float Speed;
    public KeyCode Up, Down;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Up))
        {
            rb.AddForce(rb.transform.up * Speed * 100 * Time.deltaTime);
        }
        else if (Input.GetKey(Down))
        {
            rb.AddForce(-rb.transform.up * Speed * 100 * Time.deltaTime);
        }
    }
}
