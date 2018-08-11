using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Planet : MonoBehaviour
{
    GameObject player;
    [Range(0.1f, 1f)]
    public float gravitation = 0.45f;
    [Range(4, 20)]
    public float gravitationRadius = 11;

    private Rigidbody2D rbPlayer;

    void Start()
    {
        player = GameManager.Player;
        rbPlayer = player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist < gravitationRadius)
        {
            Vector2 force = (transform.position - player.transform.position).normalized * gravitation * (gravitationRadius - dist);
            rbPlayer.AddForce(force);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Random.ColorHSV();
        Gizmos.DrawWireSphere(transform.position, gravitationRadius);
    }
}
