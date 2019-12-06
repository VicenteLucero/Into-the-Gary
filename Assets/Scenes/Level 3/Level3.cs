using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
    static int health = 100;
    static int objective = 0;
    static Vector3 gary_position = new Vector3(3.87f, -0.45f, -15.76f);
    static Vector3 gary_rotation = new Vector3(0f, 266f, 0f);
    public GameObject objectiveText;
    static string objText = "Ve a la Mesa";

    void Start()
    {
        
    }

    public Vector3 GetGPosition()
    {
        return gary_position;
    }

    public Vector3 GetGRotation()
    {
        return gary_rotation;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetGPosition(Vector3 pos, Vector3 rot)
    {
        gary_position = pos;
        gary_rotation = rot;
    }

    public void ClearObjective(string tag)
    {


    }

    void SetObjetiveText(string newObj)
    {
        objectiveText = GameObject.FindGameObjectWithTag("ObjectiveText");
        objectiveText.GetComponent<Text>().text = "OBJECTIVE: " + newObj;
    }
}
