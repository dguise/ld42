using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float spaceStartTime;
    private float spaceMaxTime = 2f;

    public float timeScale;
    public float turnSpeed;

    private float discStartScale = 0.3f;
    private float discEndScale = 1.4f;

    private Transform engineDisc;
    private ParticleSystem ps;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        engineDisc = transform.Find("EngineDisc");
        ps = transform.Find("EngineParticles").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceStartTime = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            float timeDiff = Time.time - spaceStartTime;
            rb.AddForce(-transform.up * timeDiff * timeScale);
            DisableStuff();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (!engineDisc.gameObject.activeSelf)
                EnableStuff();
            ChargeUp();
        }

        if (Input.GetKey(KeyCode.A))
        {
            float t = turnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + Mathf.LerpAngle(0, 5, t));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            float t = turnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + Mathf.LerpAngle(0, -5, t));
        }
    }

    void ChargeUp()
    {
        float timeFactor = Mathf.Min((Time.time - spaceStartTime) / spaceMaxTime, 1f);
        float scale = discStartScale + (discEndScale - discStartScale) * timeFactor;
        engineDisc.transform.localScale = new Vector3(scale, scale, scale);
    }

    void DisableStuff()
    {
        engineDisc.gameObject.SetActive(false);
        ps.gameObject.SetActive(false);
        ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    void EnableStuff()
    {
        engineDisc.gameObject.SetActive(true);
        ps.gameObject.SetActive(true);
        ps.Play();
    }
}