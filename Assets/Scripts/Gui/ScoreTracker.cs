using Assets.Scripts.Helper;
using Assets.Scripts.Helper.Constants;
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
        if (GameManager.Player)
        {
            GameManager.Player = GameObject.FindWithTag(Tags.Player);
        }
        if (GameManager.Player != null)
        {
            var playerController = GameManager.Player.GetComponent<SpacebarController>();
            if (playerController != null)
                playerController.OnGainScore += OnScore;
        }
    }

    void OnScore()
    {
        var newScore = GameManager.Score + 1;
        if (newScore > GameManager.Score)
        {
            GameManager.Score = newScore;
            text.text = newScore.ToString("N0");
        }
    }
}
