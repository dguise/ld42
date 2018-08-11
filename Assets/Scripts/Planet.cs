using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(CircleCollider2D))]
public class Planet : MonoBehaviour
{
    GameObject player;
    [Range(0.1f, 1f)]
    public float gravitation = 0.45f;
    [Range(4, 20)]
    public float gravitationRadius = 11;
    [Range(-2, 2f)]
    public float rotationSpeed = 0.9f;

    private CircleCollider2D gravitationTrigger;

    void Start()
    {
        gravitationTrigger = GetComponents<CircleCollider2D>()[1];
        gravitationTrigger.isTrigger = true;
        gravitationTrigger.radius = gravitationRadius / transform.localScale.x;
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);

        foreach (var objectInVicinity in objectsInRange)
        {
            float dist = Vector2.Distance(transform.position, objectInVicinity.transform.position);
            Vector2 force = (transform.position - objectInVicinity.transform.position).normalized * gravitation * (gravitationRadius - dist);
            objectInVicinity.AddForce(force);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gravitationRadius);
    }

    private List<Rigidbody2D> objectsInRange = new List<Rigidbody2D>();
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var rb = collider.GetComponent<Rigidbody2D>();
        if (rb != null)
            objectsInRange.Add(rb);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var rb = collider.GetComponent<Rigidbody2D>();
        if (rb != null)
            objectsInRange.Remove(rb);
    }
}
