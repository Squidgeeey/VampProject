using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    [SerializeField] private string m_sceneName;
    public void GoalComplete()
    {
        SceneManager.LoadScene(m_sceneName);
    }
}