using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    static int level = 0;
    List<string> levels = new List<string>();
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
    }

    // Update is called once per frame
    public void PlayButton()
    {
        SceneManager.LoadScene(levels[level]);
    }

    public void ContinueButton()
    {
        if(level == 7)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            level += 1;
            SceneManager.LoadScene(levels[level]);
        }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(levels[level]);
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
        SceneManager.LoadScene("Menu");
    }

    public void Level1()
    {
        level = 0;
        SceneManager.LoadScene(levels[level]);
    }

    public void Level2()
    {
        level = 1;
        SceneManager.LoadScene(levels[level]);

    }

    public void Level3()
    {
        level = 2;
        SceneManager.LoadScene(levels[level]);
    }

    public void Level4()
    {
        level = 3;
        SceneManager.LoadScene(levels[level]);
    }

    public void Level5()
    {
        level = 4;
        SceneManager.LoadScene(levels[level]);
    }

    public void Level6()
    {
        level = 5;
        SceneManager.LoadScene(levels[level]);
    }

    public void Level7()
    {
        level = 6;
        SceneManager.LoadScene(levels[level]);
    }

    public void Level8()
    {
        level = 7;
        SceneManager.LoadScene(levels[level]);
    }
}
