using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(CircleCollider2D))]
public class Planet : MonoBehaviour
{
    GameObject player;
    [Range(0.1f, 50f)]
    public float gravitation = 0.45f;
    [Range(4, 50)]
    public float gravitationRadius = 11f;
    [Range(0f, 10f)]
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
            if (objectInVicinity == null) {
                objectsInRange.Remove(objectInVicinity);
                break;
            }

            float dist = Vector2.Distance(transform.position, objectInVicinity.transform.position);
            float gravitationFactor = 1 - dist / gravitationRadius;
            Vector2 force = (transform.position - objectInVicinity.transform.position).normalized * gravitation * gravitationFactor;
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
        {
            objectsInRange.Add(rb);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var rb = collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            objectsInRange.Remove(rb);
        }
    }
}
