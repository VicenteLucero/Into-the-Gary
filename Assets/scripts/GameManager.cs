using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int health;
    static int currentLevel = 0;
    static int currentObjective = 0;
    


    private void Start()
    {
        if (currentObjective != 0 && SaveInfo.pov == false)
        {
            GameObject.FindGameObjectWithTag("gary").transform.position = SaveInfo.gPosition;
            GameObject.FindGameObjectWithTag("gary").transform.eulerAngles = SaveInfo.gRotation;
        }
        if (currentObjective == 0 && (SaveInfo.pov == false || SaveInfo.pov == true) )
        {
            health = 100;
            GameObject.FindGameObjectWithTag("body").GetComponent<AudioSource>().Play();
        }


        currentLevel = SaveInfo.GetLevel();

    }


    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int salud)
    {
        health = salud;
    }

    public void ClearObj(string tag)
    {
        if (currentLevel == 1)
        {
            GetComponent<Level1>().ClearObjective(tag);
            currentObjective += 1;
        }

        if (currentLevel == 2)
        {
            GetComponent<Level2>().ClearObjective(tag);
            currentObjective += 1;
        }

        if (currentLevel == 3)
        {
            GetComponent<Level3>().ClearObjective(tag);
            currentObjective += 1;
        }

        if (currentLevel == 4)
        {
            GetComponent<Level4>().ClearObjective(tag);
            currentObjective += 1;
        }

        if (currentLevel == 5)
        {
            GetComponent<Level5>().ClearObjective(tag);
            currentObjective += 1;
        }
        if (currentLevel == 6)
        {
            GetComponent<Level6>().ClearObjective(tag);
            currentObjective += 1;
        }

        if (currentLevel == 7)
        {
            GetComponent<Level7>().ClearObjective(tag);
            currentObjective += 1;
        }

        if (currentLevel == 8)
        {
            GetComponent<Level8>().ClearObjective(tag);
            currentObjective += 1;
        }
    }


    public void EndGame()
    {
        currentObjective = 0;
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void LevelComplete()
    {
        currentObjective = 0;
        SceneManager.LoadScene("LvlComplete");
    }
}

