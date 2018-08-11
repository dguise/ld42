using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectXY : MonoBehaviour
{
    private GameObject target;
    private void Start()
    {
        target = GameManager.Player;
    }

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
