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
    private float moveSpeed = 5f;
    private float cameraSensitivity = 10f;
    public bool pov;
    public Animator animator;
    public List<string> parts;
    // Start is called before the first frame update
    void Start()
    {
        current_health = FindObjectOfType<GameManager>().health;
        damageAmount = 0;
        healthText = Canvas.FindObjectOfType<Text>();
        SetHealthText();
        animator = GetComponent<Animator>();
        animator.SetBool("isSitting", false);
        transform.position = new Vector3(3.87f, -0.45f, -15.76f);
        transform.eulerAngles = new Vector3(0f, 266f, 0f);
        parts = new List<string>{"upperArmL", "upperArmR", "upperLegL", "upperLegR"};
        GetComponent<AudioSource>().Play(0);
        

    }

    // Update is called once per frame
    void Update()
    {
        pov = FindObjectOfType<CameraMov>().firstPerson;
        current_health = FindObjectOfType<GameManager>().health;


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sphere"))
        {
            damageAmount = other.gameObject.GetComponent<SphereDanger>().damage;
        }

        if (other.gameObject.CompareTag("cylinder"))
        {
            damageAmount = other.gameObject.GetComponent<CylinderDanger>().damage;
        }

        if (other.gameObject.CompareTag("objective_chair"))
        {
            if (pov == false)
            {
                transform.position = new Vector3(0.321f, -0.616f, -17.422f);
                transform.rotation = other.transform.rotation;
                Debug.Log("choque con una silla");
                FindObjectOfType<CameraMov>().ChangePerspective(other.tag);
                animator.SetBool("isSitting", true);
                other.GetComponent<AudioSource>().Play();
            }
            
        }

        if (other.gameObject.CompareTag("Door"))
        {
            FindObjectOfType<GameManager>().ClearObjective(other.tag);
        }

        current_health = current_health - damageAmount;
        SetHealthText();
        damageAmount = 0;
    }

    void SetHealthText()
    {
        FindObjectOfType<GameManager>().health = current_health;
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
        int pos = Random.Range(0, 3);
        string val = parts[pos];
        parts.Remove(val);
        return val;
    }

    public void Move(InputValue value)
    {
        if (pov == false)
        {
            gary_movement = value.Get<Vector2>();
            Vector3 movement = new Vector3(gary_movement.x, 0, gary_movement.y) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
            animator.SetBool("isWalking", true);
        }

    }

    public void Camera(InputValue value)
    {
        if (pov == false)
        {
            Vector2 cam_mov = value.Get<Vector2>();
            camera_mov += new Vector3(0f, cam_mov.x * cameraSensitivity, 0f);
            FindObjectOfType<CameraMov>().Rotation(camera_mov);
        }
    }

    public void LeftArm()
    {
        animator.SetTrigger("leftArm");
    }

    public void RightArm()
    {
        animator.SetTrigger("rightArm");
    }
}
