using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreTracker : MonoBehaviour
{
    Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        var newScore = GameManager.Player.transform.position.x;
        if (newScore > GameManager.Score)
        {
            GameManager.Score = newScore;
            text.text = newScore.ToString("N0");
        }
    }
}
