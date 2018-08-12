using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnykeyToContinue : MonoBehaviour
{
    private void Start()
    {
        Fader.Instance.FadeIn();
    }

    bool doOnce = true;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Fader.Instance.FadeOut(FadeOutComplete);
        }
    }


    void FadeOutComplete()
    {
        if (doOnce)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            doOnce = false;
        }
    }
}
