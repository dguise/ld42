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

    void Start()
    {
    }

    void FixedUpdate()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, gravitationRadius);
        foreach (var hit in hits)
        {
            float dist = Vector2.Distance(transform.position, hit.transform.position);
            Vector2 force = (transform.position - hit.transform.position).normalized * gravitation * (gravitationRadius - dist);
            var rb = hit.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.AddForce(force);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gravitationRadius);
    }
}
