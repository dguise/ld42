using Assets.Scripts.Helper.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Helper
{
    public class Initializer : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.Player = GameObject.FindWithTag(Tags.Player);
        }

        private void Start()
        {
            Fader.Instance.FadeIn();
        }
    }

    public static class GameManager
    {
        public static GameObject Player { get; set; }
        public static float Score { get; set; }

        public static void PlayerHasFailedLetsGetRidOfHimMethod()
        {
            Player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            // Player.transform.localScale = Vector3.zero;
            AudioManager.instance.PlayRandomize(0, 7, 8, 9);
            Fader.Instance.FadeOut(LoadNextScene);
        }

        private static void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
