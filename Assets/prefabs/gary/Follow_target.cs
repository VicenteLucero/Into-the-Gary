using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_target : MonoBehaviour
{
    public Transform point_of_view;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = point_of_view.position;
        float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        transform.localRotation = Quaternion.Euler(new Vector4(-1f * (mouseY * 180f), mouseX * 360f, transform.localRotation.z));
    }

    
}
