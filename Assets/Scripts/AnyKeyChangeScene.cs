using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyChangeScene : MonoBehaviour
{
    public int scene = 3;

    void Start()
    {
        Fader.Instance.FadeIn();
    }

    private void Update()
    {
        if (KeyDown())
        {
            GameManager.Score = 0;
            SceneManager.LoadScene(scene);
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
