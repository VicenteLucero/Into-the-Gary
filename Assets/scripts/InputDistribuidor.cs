using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;
using UnityEngine.SceneManagement;

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
        
        
    }

    void OnMove(InputValue value)
    {
      
        //Vector2 part_mov = value.Get<Vector2>();
        //Vector2 movement = new Vector3(0f, part_mov.y, 0f);
        gary.Move(value);

    }

    void OnCamera(InputValue value)
    {
        
        gary.Camera(value);
        //Vector2 cam_mov = value.Get<Vector2>();
        //camera_mov = new Vector3(0f, cam_mov.x * cameraSensitivity, 0f);
        //FindObjectOfType<CameraMov>().Rotation(camera_mov);
    }

    void OnLeftArm()
    {
        gary.LeftArm();
    }

    void OnRightArm()
    {
        gary.RightArm();
    }

    void OnBack()
    {
        SceneManager.LoadScene("Menu");
    }

    void OnQuit()
    {
        Application.Quit();
    } 

}
