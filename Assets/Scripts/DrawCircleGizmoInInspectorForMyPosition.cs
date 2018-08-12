using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircleGizmoInInspectorForMyPosition : MonoBehaviour {

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
