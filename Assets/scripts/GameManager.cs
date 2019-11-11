using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool objectiveComplete = false;
    public int health = 100;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Restart();
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene("GameOver");
    }
}
