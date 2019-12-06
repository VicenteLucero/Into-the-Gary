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
    

    void OnCamera(InputValue value)
    {
        gary.Camera(value);
    }


    void OnBack()
    {
        SceneManager.LoadScene("Menu");
    }

    void OnQuit()
    {
        Application.Quit();
    } 

    void OnMovement(InputValue value)
    {
        Vector3 move = value.Get<Vector2>();
        Vector3 movement = new Vector3(move.x, 0, 0)*200;
        if (partControl == "LA" || partControl == "RA")
        {
            movement = new Vector3(move.x, move.y, 0) * 10;
        }
        rb.AddForce(movement);
    }

   



}
