using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;
using UnityEngine.SceneManagement;

public class InputDistribuidor : MonoBehaviour
{
    public string partControl;
    public GaryController gary;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        partControl = FindObjectOfType<GaryController>().SetPart();
        if (partControl == "LA")
        {
            rb = GameObject.FindGameObjectWithTag("LA").GetComponent<Rigidbody>();
        }
        if (partControl == "RA")
        {
            rb = GameObject.FindGameObjectWithTag("RA").GetComponent<Rigidbody>();
        }
        if (partControl == "LL")
        {
            rb = GameObject.FindGameObjectWithTag("LL").GetComponent<Rigidbody>();
        }
        if (partControl == "RL")
        {
            rb = GameObject.FindGameObjectWithTag("RL").GetComponent<Rigidbody>();
        }
        gary = FindObjectOfType<GaryController>();
    }

    private void Update()
    {
        if (Input.GetKey("backspace"))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    void OnCamera(InputValue value)
    {
        gary.Camera(value);
    }


    void OnMovement(InputValue value)
    {
        Vector3 move = value.Get<Vector2>();
        Vector3 movement = new Vector3(move.x, 0f, move.y)*1000;
        if (partControl == "LA" || partControl == "RA")
        {
            movement = new Vector3(0f, move.y, -move.x);
            rb.velocity = movement;
        }
        else
        {
            rb.velocity = movement * 0.003f;
        }
        
    }

   



}
