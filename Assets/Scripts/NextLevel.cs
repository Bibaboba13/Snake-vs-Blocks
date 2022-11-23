using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel2()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadNextLevel3()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }
}
