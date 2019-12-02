using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public Transform target;
    public float distance = 1f;
    
    public bool firstPerson;
    // Start is called before the first frame update
    void Start()
    {
        
        
        firstPerson = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Rotation(Vector3 rotation)
    {
        transform.eulerAngles = rotation;
       
    }

    

    public void ChangePerspective(string tag)
    {
        Debug.Log("change was called");
        if (firstPerson == false)
        {
            if(tag == "objective_chair")
            {
                transform.eulerAngles = new Vector3(45f, 180f, 0f);
                transform.position = new Vector3(0.422f, 1.54f, -17.471f);
                firstPerson = true;
            }
        }

        else if (firstPerson == true)
        {
            
            firstPerson = false;
        }
    }

}
