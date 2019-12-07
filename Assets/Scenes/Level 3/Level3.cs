using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{

    static int objective = 0;
    public GameObject objectiveText;
    private int count = 0;
    static string objText = "Ve a la Mesa";

    void Start()
    {
        if (SaveInfo.GetLevel() == 3)
        {
            SetObjetiveText(objText);
        }
    }

    public void ClearObjective(string tag)
    {
        if(tag == "ham" || tag == "bread" || tag == "jar")
        {

            count += 1;
            if (count == 3)
            {
                FindObjectOfType<GameManager>().LevelComplete();
            }
        }
    }

    void SetObjetiveText(string newObj)
    {
        objectiveText = GameObject.FindGameObjectWithTag("ObjectiveText");
        objectiveText.GetComponent<Text>().text = "OBJECTIVE: " + newObj;
    }
}
