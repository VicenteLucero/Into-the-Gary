using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    
    static int objective = 0;
    static Vector3 gary_position = new Vector3(0.009f, 6.79f, -7.894794f);
    static Vector3 gary_rotation = new Vector3(0f, 0f, 0f);
    public GameObject objectiveText;
    static string objText = "Ve a la Cocina";
    GameObject gary;

    void Start()
    {
        gary = GameObject.FindGameObjectWithTag("gary");
        if (SaveInfo.GetLevel()== 2)
        {
            SetObjetiveText(objText);
            gary.transform.position = gary_position;
            gary.transform.eulerAngles = gary_rotation;

        }
    }

    public void SetGPosition(Vector3 pos, Vector3 rot)
    {
        gary_position = pos;
        gary_rotation = rot;
    }

    public void ClearObjective(string tag)
    {
        if (tag == "Finish")
        {
            FindObjectOfType<GameManager>().LevelComplete();
        }
    }

    void SetObjetiveText(string newObj)
    {
        objectiveText = GameObject.FindGameObjectWithTag("ObjectiveText");
        objectiveText.GetComponent<Text>().text = "OBJECTIVE: " + newObj;
    }
}
