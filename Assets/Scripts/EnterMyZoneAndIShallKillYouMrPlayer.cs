using Assets.Scripts.Helper;
using Assets.Scripts.Helper.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnterMyZoneAndIShallKillYouMrPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == Tags.Player)
            GameManager.PlayerHasFailedLetsGetRidOfHimMethod();
    }
}
