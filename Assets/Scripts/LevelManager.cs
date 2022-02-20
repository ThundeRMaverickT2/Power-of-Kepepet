using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        int currentActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentActiveScene);
    }
}
