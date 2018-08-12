using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ActivateAndSetSpeedTowardsPlacedPoint : MonoBehaviour
{
    private Vector3 direction;
    public float speed = 1.0f;
    private GameObject goToGoTo;
    private bool activated = false;
    private Rigidbody2D rb;

    void Start()
    {
        goToGoTo = this.transform.GetChild(0).gameObject;
        rb = this.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0.0f;
        rb.simulated = false;
    }

    void Update()
    {
        if (!activated && this.GetComponent<SpriteRenderer>().isVisible)
        {
            activated = true;
            direction = (goToGoTo.transform.position - this.transform.position).normalized;
            rb.simulated = true;
        }
        else
        {
            Vector3 v = transform.position;
            v += (direction * (speed * Time.deltaTime));
            transform.position = v;
        }
    }

    private void OnValidate()
    {
        if (this.gameObject.GetComponentInChildren<DrawCircleGizmoInInspectorForMyPosition>() == null)
        {
            GameObject go = new GameObject();
            go.name = "GoTo Target";
            go.transform.parent = this.transform;
            go.transform.localPosition = Vector3.zero;
            go.AddComponent<DrawCircleGizmoInInspectorForMyPosition>();
        }
    }
}
