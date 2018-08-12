using Assets.Scripts.Helper.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Helper
{
    public class Initializer : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.Player = GameObject.FindWithTag(Tags.Player);
        }
    }

    public static class GameManager
    {
        public static GameObject Player { get; set; }
        public static float Score { get; set; }

        public static void PlayerHasFailedLetsGetRidOfHimMethod()
        {
            Player.SetActive(false);
            //GameObject.Destroy(Player);
        }
    }
}
