using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string firstLevel;
    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
