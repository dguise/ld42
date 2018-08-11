using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    private static Fader _instance = null;
    public static Fader Instance {
        get {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<GameObject>("FaderCanvas")).GetComponentInChildren<Fader>();
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    Image fadeImage;

    private Color invisible = new Color(0, 0, 0, 0);
    private Color visible = new Color(0, 0, 0, 1);

    private float speed = 1;

    private Coroutine fadeRoutine = null;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        fadeImage.color = invisible;
    }

    public void FadeOut(Action doneCallback = null)
    {
        fadeImage = GetComponent<Image>();
        if (fadeRoutine == null)
            fadeRoutine = StartCoroutine(_FadeOut(doneCallback));
    }

    private IEnumerator _FadeOut(Action doneCallback)
    {
        float tick = 0f;
        do
        {
            fadeImage.color = Color.Lerp(invisible, visible, tick * Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        } while (fadeImage.color != visible);

        if (doneCallback != null)
            doneCallback();
    }

    public void FadeIn(Action doneCallback = null)
    {
        fadeImage = GetComponent<Image>();
        if (fadeRoutine == null)
            fadeRoutine = StartCoroutine(_FadeIn(doneCallback));
    }

    private IEnumerator _FadeIn(Action doneCallback)
    {
        float tick = 0f;
        do
        {
            fadeImage.color = Color.Lerp(visible, invisible, tick * Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        } while (fadeImage.color != invisible);

        if (doneCallback != null)
            doneCallback();
    }
}
