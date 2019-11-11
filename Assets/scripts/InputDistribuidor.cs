using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;

public class InputDistribuidor : MonoBehaviour
{
    public string partControl;
    public GaryController gary;
    // Start is called before the first frame update
    void Start()
    {
        partControl = FindObjectOfType<GaryController>().SetPart();
        gary = FindObjectOfType<GaryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnStartButton()
    {
        Debug.Log("start");
        
    }

    void OnMove(InputValue value)
    {
        Debug.Log("moving");
        //Vector2 part_mov = value.Get<Vector2>();
        //Vector2 movement = new Vector3(0f, part_mov.y, 0f);
        gary.Move(partControl);

    }

    void OnCamera(InputValue value)
    {
        Debug.Log("Camera");

    }

}
