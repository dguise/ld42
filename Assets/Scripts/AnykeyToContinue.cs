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
        if (doOnce && Input.anyKeyDown)
        {
            doOnce = false;
            Fader.Instance.FadeOut(FadeOutComplete);
        }
    }


    void FadeOutComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
