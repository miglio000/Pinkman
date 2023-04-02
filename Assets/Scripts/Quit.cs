using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    private SceneManager sc;
    public void QuitGame()
    {
        Application.Quit();
    }
}
