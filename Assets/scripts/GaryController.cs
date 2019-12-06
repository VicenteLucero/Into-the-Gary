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

        current_health = FindObjectOfType<Level1>().GetHealth();
        damageAmount = 0;
        healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
        SetHealthText();
        parts = new List<string>{"LL", "RL"};
        GetComponent<AudioSource>().Play(0);
        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        current_health = FindObjectOfType<Level1>().GetHealth();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("objective_chair"))
        {
            Debug.Log("choque con una silla");
            other.GetComponent<AudioSource>().Play();
            FindObjectOfType<GameManager>().ClearObj(other.tag);


        }

        if (other.gameObject.CompareTag("Door"))
        {
            FindObjectOfType<GameManager>().ClearObj(other.tag);
        }

        current_health = current_health - damageAmount;
        SetHealthText();
        damageAmount = 0;
    }

    void SetHealthText()
    {
        FindObjectOfType<Level1>().GetHealth();
        if (current_health <= 0)
        {
            healthText.text = "HEALTH: DEAD";
            FindObjectOfType<GameManager>().EndGame();
            GetComponent<PlayerInput>().enabled = false;
        }
        else
        {
            healthText.text = "HEALTH: " + current_health.ToString();
        }
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

    //SOLO  PARA TEST AMBIENTE
    public void Camera(InputValue value)
    {
         Vector2 cam_mov = value.Get<Vector2>();
         camera_mov += new Vector3(0f, cam_mov.x * cameraSensitivity, 0f);
         FindObjectOfType<CameraMov>().Rotation(camera_mov);
    }

   
}
