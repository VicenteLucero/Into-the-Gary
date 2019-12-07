using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;


public class GaryController : MonoBehaviour
{

    private int current_health;
    private int damageAmount;
    public Text healthText;
    Vector2 gary_movement;
    Vector3 camera_mov;
    public float moveSpeed = 5f;
    private float cameraSensitivity = 10f;
    public List<string> parts;
    Rigidbody body;
    int n = 1;
    
 
    // Start is called before the first frame update
    void Start()
    {

        current_health = FindObjectOfType<GameManager>().GetHealth();
        damageAmount = 0;
        healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        SetHealthText();
        if (SaveInfo.pov == false)
        {
            parts = new List<string> { "LL", "RL" };
        }
        if (SaveInfo.pov == true)
        {
            parts = new List<string> { "LA", "RA" };
        }
        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        current_health = FindObjectOfType<GameManager>().GetHealth();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("objective_chair"))
        {            
            other.GetComponent<AudioSource>().Play();
            FindObjectOfType<GameManager>().ClearObj(other.tag);
        }

        if (other.gameObject.CompareTag("Door"))
        {

            FindObjectOfType<GameManager>().ClearObj(other.tag);
        }

        if (other.gameObject.CompareTag("pills"))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            FindObjectOfType<GameManager>().ClearObj(other.tag);
        }

        if (other.gameObject.CompareTag("Water"))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            FindObjectOfType<GameManager>().ClearObj(other.tag);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            FindObjectOfType<GameManager>().ClearObj(other.tag);
        }
        if (other.gameObject.CompareTag("potion"))
        {
            damageAmount = 20;
            other.gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("knife"))
        {
            damageAmount = 35;
            other.gameObject.GetComponent<AudioSource>().Play();
        }

        if (other.gameObject.CompareTag("bread") || other.gameObject.CompareTag("jar") || other.gameObject.CompareTag("ham"))
        {
            Debug.Log("INGREDIENTES!!!!!");        
            FindObjectOfType<GameManager>().ClearObj(other.tag);
            other.gameObject.SetActive(false);
        }

            current_health = current_health - damageAmount;
        SetHealthText();
        damageAmount = 0;
    }

    void SetHealthText()
    {
        FindObjectOfType<GameManager>().GetHealth();
        if (current_health <= 0)
        {
            healthText.text = "HEALTH: DEAD";
            FindObjectOfType<GameManager>().EndGame();
        }
        else
        {
            healthText.text = "HEALTH: " + current_health.ToString();
        }
        FindObjectOfType<GameManager>().SetHealth(current_health);
    }

    public string SetPart()
    {
        int pos = Random.Range(0, n);
        string val = parts[pos];
        parts.Remove(val);
        return val;
    }

    public void PositionSet(Vector3 pos)
    {
        transform.position = pos;
    }

    public void RotationSet(Vector3 rot)
    {
        transform.eulerAngles = rot;
    }


    //SOLO PARA TEST AMBIENTE
    public void Move(InputValue value)
    {
        gary_movement = value.Get<Vector2>();
        Vector3 movement = new Vector3(-gary_movement.y, 0, gary_movement.x) * moveSpeed;
        Debug.Log(movement.z);
        body.AddForce(movement);
    }

    
    public void Camera(InputValue value)
    {
         if(SaveInfo.pov == false)
        {
            Vector2 cam_mov = value.Get<Vector2>();
            camera_mov += new Vector3(-cam_mov.y * cameraSensitivity, cam_mov.x * cameraSensitivity, 0f);
            FindObjectOfType<CameraMov>().Rotation(camera_mov);
        }
    }

   
}
