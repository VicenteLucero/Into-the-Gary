using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    
    static int objective = 0;
    public GameObject objectiveText;
    static string objText = "Ve a la Mesa";

    void Start()
    {
        if(SaveInfo.GetLevel() == 1)
        {
            SetObjetiveText(objText);
        }
        if(SaveInfo.GetLevel() == 1 && objective == 0)
        {
            
        }
    }

    

    


    public void ClearObjective(string tag)
    {
        if (objective == 0 && tag == "objective_chair")
        {
            objective = 1;
            objText = "Toma tus pastillas";
            SaveInfo.gPosition = GameObject.FindGameObjectWithTag("gary").transform.position;
            SaveInfo.gRotation = GameObject.FindGameObjectWithTag("gary").transform.eulerAngles;
            SaveInfo.pov = true;
            SceneManager.LoadScene("perspective_1");
        }

        if (objective == 1 && tag == "pills")
        {
            objective = 2;
            SetObjetiveText("Drink Water");
        }

        if (objective == 2 && tag == "Water")
        {
            objective = 3;
            objText = "Go to the Kitchen";
            SaveInfo.pov = false;
            SceneManager.LoadScene("Level1");
        }

        if (objective == 3 && tag == "Door")
        {
            FindObjectOfType<GameManager>().LevelComplete();
        }

    }

    public void SetObjetiveText(string newObj)
    {
        
        objectiveText.GetComponent<Text>().text = "OBJECTIVE: " + newObj;
    }
}
