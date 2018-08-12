using Assets.Scripts.Helper;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Rigidbody2D rb;
    float normalZoom;
    float minZoom;
    float smoothTime = 0.3f;

    private void Start()
    {
        target = GameManager.Player.transform;
        rb = target.GetComponent<Rigidbody2D>();
        normalZoom = transform.position.z;
        minZoom = normalZoom - 30;
    }

    private float zVelocity;
    void LateUpdate()
    {
        float zoom = normalZoom;
        // TODO: Use rb.velocity.magnitude / speedAtMinZoom instead so that it zooms further away the faster you go.
        if (rb.velocity.magnitude > 5)
        {
            zoom = Mathf.SmoothDamp(normalZoom, minZoom, ref zVelocity, smoothTime);       
        }
        transform.position = new Vector3(target.position.x, transform.position.y, zoom);
    }
}
