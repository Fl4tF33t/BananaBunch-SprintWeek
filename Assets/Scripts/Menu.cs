using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
