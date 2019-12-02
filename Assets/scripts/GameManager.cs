using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool objectiveComplete = false;
    public int health = 100;
    public int objective = 0;
    public GameObject objectiveText;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Restart();
        }

    }

    public void ClearObjective(string tag)
    {
        if (objective == 0)
        {
            objective = 1;
            SetObjetiveText("Take Your Pills");
        }

        if (objective == 1 && tag == "pills")
        {
            objective = 2;
            SetObjetiveText("Drink Water");
        }

        if (objective == 2 && tag == "Water")
        {
            objective = 3;
            SetObjetiveText("Go to the BathRoom");
            FindObjectOfType<GaryController>().pov = false;
            FindObjectOfType<CameraMov>().ChangePerspective(tag);
            FindObjectOfType<GaryController>().animator.SetBool("isSitting", false);
        }

        if (objective == 3 && tag == "Door")
        {
            LevelComplete();
        }

    }

    void LevelComplete()
    {
        SceneManager.LoadScene("LvlComplete");
    }

    void SetObjetiveText(string newObj)
    {
        objectiveText = GameObject.FindGameObjectWithTag("ObjectiveText");
        objectiveText.GetComponent<Text>().text = "OBJECTIVE: " + newObj;
    }

    void Restart()
    {
        SceneManager.LoadScene("GameOver");
    }
}

