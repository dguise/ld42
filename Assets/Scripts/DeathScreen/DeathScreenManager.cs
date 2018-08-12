using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{

    void Start()
    {
        Fader.Instance.FadeIn();
    }

    private void Update()
    {
        if (KeyDown())
        {
            GameManager.Score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    bool KeyDown()
    {
        return (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));
    }
}
