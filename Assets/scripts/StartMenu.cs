using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    static int level = 0;
    List<string> levels = new List<string>();
    static string currentScene;
    Text canvasText;
    
    // Start is called before the first frame update
    void Start()
    {
        levels.Add("Level1");
        levels.Add("Level2");
        levels.Add("Level3");
        levels.Add("Level4");
        levels.Add("Level5");
        levels.Add("Level6");
        levels.Add("Level7");
        levels.Add("Level8");

        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "LvlComplete")
        {
            canvasText = GameObject.FindGameObjectWithTag("winText").GetComponent<Text>();
            if (level == 0)
            {
                canvasText.text = "¡¡¡Tomaste tus Pastillas!!!" + "\r\n" +"¡¡¡FELICIDADES!!!" + "\r\n" + "Ya no acumularas estupideces"; 
            }

            if (level == 1)
            {
                canvasText.text = "Que Sorpresa...Llegaste a la Cocina" + "\r\n" + "¿Tienes hambre?" + "\r\n" + "Preparate algo de comer idiota";
            }

            if (level == 2)
            {
                canvasText.text = "Guatita Llena" + "\r\n" + "Corazon contento" + "\r\n" + "Como decia mi abuelita";
            }

            if (level == 3)
            {
                canvasText.text = "" + "\r\n" + "" + "\r\n" + "";
            }

            if (level == 4)
            {
                canvasText.text = "" + "\r\n" + "" + "\r\n" + "";
            }

            if (level == 5)
            {
                canvasText.text = "" + "\r\n" + "" + "\r\n" + "";
            }

            if (level == 6)
            {
                canvasText.text = "" + "\r\n" + "" + "\r\n" + "";
            }

            if (level == 7)
            {
                canvasText.text = "" + "\r\n" + "" + "\r\n" + "";
            }
        }
    }

    public void PlayButton()
    {
        SaveInfo.SetLevel(1);
        SceneManager.LoadScene(levels[level]);
    }

    public void ContinueButton()
    {
        if(level == 7)
        {
            SceneManager.LoadScene("Menu");
        }
        if(level == 2)
        {
            level += 1;
            SaveInfo.SetLevel(level + 1);
            SaveInfo.pov = true;
            SceneManager.LoadScene("perspective_2");
        }
        else
        {
            level += 1;
            SaveInfo.SetLevel(level + 1);
            SceneManager.LoadScene("House");
        }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("House");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitButton()
    {
        level = 0;
        Application.Quit();
    }

    public void BackButton()
    {
        level = 0;
        SaveInfo.pov = false;
        SceneManager.LoadScene("Menu");
    }

    public void Level1()
    {
        level = 0;
        SceneManager.LoadScene("House");
    }

    public void Level2()
    {
        level = 1;
        SaveInfo.SetLevel(level + 1);
        SceneManager.LoadScene("House");

    }

    public void Level3()
    {
        level = 2;
        SaveInfo.pov = true;
        SaveInfo.SetLevel(level + 1);
        SceneManager.LoadScene("perspective_2");
    }

    public void Level4()
    {
        level = 3;
        SaveInfo.SetLevel(level + 1);
        SceneManager.LoadScene("House");
    }

    public void Level5()
    {
        level = 4;
        SaveInfo.SetLevel(level + 1);
        SceneManager.LoadScene("House");
    }

    public void Level6()
    {
        level = 5;
        SaveInfo.SetLevel(level + 1);
        SceneManager.LoadScene("House");
    }

    public void Level7()
    {
        level = 6;
        SaveInfo.SetLevel(level + 1);
        SceneManager.LoadScene("House");
    }

    public void Level8()
    {
        level = 7;
        SaveInfo.SetLevel(level + 1);
        SceneManager.LoadScene("House");
    }
}
